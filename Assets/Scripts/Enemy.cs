using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject target;
    [SerializeField]
    EnemyNavigator navigator;
    [SerializeField]
    Rigidbody rg;
    [SerializeField]
    bool isFight;
    [SerializeField]
    HealthController healthController;
    [SerializeField]
    RenderChangerEnemies renderChangerEnemies;

    

    private void Start()
    {
        isFight = false;
        target = GameObject.FindGameObjectWithTag("Player");
        navigator = gameObject.AddComponent<EnemyNavigator>();
        rg = GetComponent<Rigidbody>();
        healthController = gameObject.GetComponentInChildren<HealthController>();
        renderChangerEnemies = GameObject.Find("Directional Light").GetComponent<RenderChangerEnemies>();
        healthController.Health = 100;
        StartCoroutine(CheckRender());
    }

    private void OnBecameVisible()
    {
        isFight = true;
    }

    private void FixedUpdate()
    {
      
       if (isFight)
        {
            if (target != null)
                navigator.Follow(target.transform, rg);
        }
        else
        {
            navigator.FollowToPoint(rg);
        }
    }
    
   
    

    IEnumerator CheckRender()
    {
        yield return new WaitForSeconds(1f);
        if(Vector3.Distance(transform.position , target.transform.position) > 300)
            renderChangerEnemies.RenderDisable(transform);
        else
            renderChangerEnemies.RenderEnable(transform);

        StartCoroutine(CheckRender());
    }



}

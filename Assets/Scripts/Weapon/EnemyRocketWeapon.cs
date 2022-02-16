using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketWeapon : MonoBehaviour , IWeapon
{
    public GameObject rocketPrefab;

    Player player;
    public float projectileSpeed = 40f;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(DelayedStart());
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(3f);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Repeat();
    }

        // Update is called once per frame
    void Repeat()
    {
        if (Vector3.Distance(transform.position,player.PlayerGetPosition()) < 200)
            StartCoroutine(ShotDelay());
        if (Vector3.Distance(transform.position, player.PlayerGetPosition()) > 200)
        { 
            StartCoroutine(Wait());
        }
        
    }

    IEnumerator ShotDelay()
    {
       // print("Zhdet: " + gameObject);
        yield return new WaitForSeconds(3f);
        TempFire();
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Repeat();
    }
    public void TempFire()
    {
       // print("Выстрелил: " + gameObject);
        GameObject rocketPrefabGO = Instantiate<GameObject>(rocketPrefab);
        rocketPrefabGO.tag = "EnemyProjectile";
        rocketPrefabGO.layer = 11;
        SetLayerRecursively(rocketPrefabGO, 11);
        rocketPrefabGO.transform.position = transform.position;
        rocketPrefabGO.transform.forward = transform.forward;
        rocketPrefabGO.transform.Translate(transform.up.normalized * 10);
        Repeat();
    }
    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (!obj)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (!child)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}

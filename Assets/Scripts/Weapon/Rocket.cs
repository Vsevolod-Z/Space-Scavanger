using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour

{

    [Header("Set in Inspector")]
    float damage = 10f;

    [Header("Set Dynamically")]
    EnemyNavigator navigator;
    [SerializeField]
    Vector3 nearestPosition;
    [SerializeField]
    Vector3 firstPosition;
    HealthController HealthController;
    Player player;
    List<GameObject> enemiesList;
    

    void Start()
    {
        enemiesList = GameObject.Find("Directional Light").GetComponent<EnemiesSpawner>().GetEnemiesList();
        navigator = gameObject.AddComponent<EnemyNavigator>();
        //navigator = transform.GetComponent<Navigator>();
        HealthController = gameObject.GetComponentInChildren<HealthController>();
        HealthController.Health = 10;
        
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();        
    }


 private void Update()
    {
        SearechTarget();
    }
    private void FixedUpdate()
    {

        if (nearestPosition != new Vector3(0,0,0))
        {
           
            navigator.Follow(nearestPosition, 70, gameObject.transform);
            StartCoroutine(RocketDestroyer());
        }
        StartCoroutine(RocketDestroyer());

    }

    public void SearechTarget()
    {
        firstPosition = gameObject.transform.position;
        nearestPosition = Vector3.zero;
        float nearestEnemyDistance = Mathf.Infinity;

      
        if (gameObject.layer == 11) // вражеская ракета
        {
            if (player)
            {
                float currentDistance = Vector3.Distance(firstPosition, player.PlayerGetPosition());
                if (currentDistance < 160)
                {
                    nearestPosition = player.PlayerGetPosition();

                }
            }
            
        }

        if (gameObject.layer == 10) // ракета игрока
        {
            foreach (GameObject enemy in enemiesList)
            {

                float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (currentDistance < nearestEnemyDistance && currentDistance < 100)
                {
                    nearestPosition = enemy.transform.position;
                    nearestEnemyDistance = currentDistance;
                }
                
            }

        }
       

    }
    IEnumerator RocketDestroyer()
    {
        if (nearestPosition == null)
        {
           // print("nearestPosition == null ");
            yield return new WaitForSeconds(0.5f);
        }
        else
            yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisonWith = collision.gameObject;
      
        if(collisonWith.layer == 9  && gameObject.tag == "PlayerProjectile")
        {
           // print("Collision: " + gameObject.tag + " With: " + collisonWith);
            Destroy(gameObject);
            collisonWith.GetComponentInChildren<HealthController>().GetDamage(damage);
        }
        if(collisonWith.layer == 8 && gameObject.layer == 11)
        {
            Destroy(gameObject);
            collisonWith.GetComponentInChildren<PlayerHealthController>().GetDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigator : MonoBehaviour , INavigator
{
    [SerializeField]
    List<Vector3> randomPositions;
    [SerializeField]
    Vector3 targetPos;
    [SerializeField]
    Vector3 wanderingPos;
    Vector3 tempPos;

    float playerRange = 60;
    float acceleration = 2000;


    void Start()
    {
        randomPositions = GameObject.Find("Directional Light").GetComponent<DataBank>().randomPositions;
        wanderingPos = randomPositions[Random.Range(0, randomPositions.Count)];
    }


    public void Follow(Transform targetTransform, Rigidbody rg)
    {
        targetPos = targetTransform.position - transform.position;
        if (Vector3.Distance(targetTransform.position, transform.position) > playerRange)
        {
            rg.AddRelativeForce(0f, 0f, acceleration);
        }
        transform.forward = targetPos.normalized;
    }
    public void Follow(Vector3 targetPosition, float projectileSpeed, Transform projectileTransform)
    {
        targetPos = targetPosition - projectileTransform.position;
        projectileTransform.position += targetPos.normalized * (projectileSpeed + 33) * Time.deltaTime;
        projectileTransform.forward = targetPos.normalized;
    }

    public void FollowToPoint( Rigidbody rg)
    {

       tempPos = wanderingPos - transform.position;
        if (Vector3.Distance(transform.position, wanderingPos) > 2)
        {
            rg.AddRelativeForce(0f, 0f, acceleration);
        }
        if(Vector3.Distance(transform.position, wanderingPos) < 2)
        {
            wanderingPos = randomPositions[(int)Random.Range(0, randomPositions.Count)];
        }
        transform.forward = tempPos.normalized;
    }

}
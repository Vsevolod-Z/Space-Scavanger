using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;
    Rigidbody rg;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.angularVelocity = Random.insideUnitSphere * tumble;
        StartCoroutine(RandomRotation());
        
    }
    IEnumerator RandomRotation()
    {
        yield return new WaitForSeconds(Random.Range(2f,8f));
        rg.angularVelocity = Random.insideUnitSphere * tumble;
        StartCoroutine(RandomRotation());
    }

  
}
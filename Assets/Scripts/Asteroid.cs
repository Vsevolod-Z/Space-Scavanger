using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    int typeOfResource;
    Inventory PlayerInventory;
    // Start is called before the first frame update
    void Start()
    {
       typeOfResource = Random.Range(0, 4);
        PlayerInventory = FindObjectOfType<Inventory>();
       transform.GetComponentInChildren<HealthController>().Health = 100;
    }

    public void IssueAResource(float damage)
    {
        Debug.Log("typeOfResource " + typeOfResource);
        PlayerInventory.AddResource(typeOfResource, (int)(damage *Random.Range(0.4f,0.9f)));
    }

}

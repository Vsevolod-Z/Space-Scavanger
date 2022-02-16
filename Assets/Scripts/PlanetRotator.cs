using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotator : MonoBehaviour
{
    public float speed = 0.005f;
    void Update()
    {
        transform.Rotate(0f, speed*Time.deltaTime, 0f);
    }
}

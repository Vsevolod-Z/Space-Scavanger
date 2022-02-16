using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : MonoBehaviour
{
    GameObject[] trashArray;
    private void Start()
    {
        StartCoroutine(FindTrash());
    }

    IEnumerator FindTrash()
    {
        yield return new WaitForSeconds(10f);
       trashArray = GameObject.FindGameObjectsWithTag("Trash");
        if(trashArray.Length >= 1)
        DestroyTrash(trashArray);
        StartCoroutine(FindTrash());
    }

    void DestroyTrash(GameObject[] trashArray)
    {
        foreach (GameObject trash in trashArray)
        {
            Destroy(trash);
        }
        Array.Clear(trashArray,0,0);
    }
}

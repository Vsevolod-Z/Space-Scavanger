using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRocketWeapon : MonoBehaviour, IWeapon
{
    public GameObject rocketPrefab;
    public float projectileSpeed = 80f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            TempFire();
    }

    public void TempFire()
    {
        GameObject rocketPrefabGO = Instantiate<GameObject>(rocketPrefab);
        rocketPrefabGO.tag = "PlayerProjectile";
        rocketPrefabGO.layer = 10;
        SetLayerRecursively(rocketPrefabGO, 10);
        rocketPrefabGO.transform.position = transform.position;
        rocketPrefabGO.transform.forward = transform.forward;
        rocketPrefabGO.transform.Translate(transform.up.normalized * 10);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWeapon : MonoBehaviour , IWeapon
{
    public LineRenderer lr;

    Vector3 PosMouse;
    Vector3 curPosition;
    float damage = 2f;
    public Camera MainCam;

    void Awake()
    {
        MainCam = Camera.main;
        lr = transform.GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        TakeMousePosition();

        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
       
        if (Input.GetKey(KeyCode.Space))
            TempFire();
        if (Input.GetKeyUp(KeyCode.Space))
            HideProjectile();

    }
    public void TempFire()
    {
        lr.enabled = true;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit , Vector3.Distance(transform.position, curPosition)))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
                if(hit.collider.GetComponentInChildren<HealthController>())
                hit.collider.GetComponentInChildren<HealthController>().GetDamage(damage);
                if (hit.collider.GetComponent<Asteroid>())
                {
                    hit.collider.GetComponent<Asteroid>().IssueAResource(damage);
                }
            }
        }
        else lr.SetPosition(1, curPosition);
      
    }

    void TakeMousePosition()
    {
        PosMouse = Input.mousePosition;
        PosMouse.z = MainCam.transform.position.y;
        curPosition = Camera.main.ScreenToWorldPoint(PosMouse);
    }
    void HideProjectile()
    {
        lr.enabled = false;
    }

}

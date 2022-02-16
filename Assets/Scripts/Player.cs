using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float speed = 90f;
    public float sideSpeed = 90f;
    public Camera MainCam;
    public GameObject CameraMiniMap;
    public GameObject TargetForLaser;
    PlayerHealthController HealthController;
    float maxHealth = 200;



    //  private JoystickController jContr;
    Vector3 Pos;
    Vector3 PosMouse;
    Vector3 PosTargetForLaser;
    Vector3 tempCamera;
    Vector3 curPosition;
    Vector3 lookPos;

    private void Start()
    {
        HealthController = transform.GetComponent<PlayerHealthController>();
        HealthController.MaxHealth = maxHealth;
        HealthController.Health = maxHealth;
        Pos = Vector3.zero;

        MainCam = Camera.main;
        CameraMiniMap = GameObject.Find("CameraMiniMap");
        TargetForLaser = GameObject.Find("TargetForLaser");
        // jContr = GameObject.FindGameObjectWithTag("Joystick").GetComponent<JoystickController>();
    }
    void FixedUpdate()
    {

        PosTargetForLaser = curPosition;
        PosTargetForLaser.y = 12;
        TargetForLaser.transform.position = PosTargetForLaser;
        CameraMove();
        GetMousePosition();
        RotateShip();
        ShipMove();
        //transform.Translate(, 0f, 0f, Space.World);

    }
    void ShipMove()
    {
        Pos = transform.position;
        Pos.y = 12;
        transform.position = Pos;
        float sideForce = Input.GetAxis("Horizontal") * sideSpeed;
        float forwardForce = Input.GetAxis("Vertical") * speed;

        transform.Translate(sideForce * Time.deltaTime, 0f, forwardForce * Time.deltaTime, Space.World);
    }
    void RotateShip()
    {
        lookPos = curPosition - transform.position;
        lookPos.y = 0;
        transform.rotation = Quaternion.LookRotation(lookPos);

    }
    void GetMousePosition()
    {
        PosMouse = Input.mousePosition;
        PosMouse.z = MainCam.transform.position.y;
        // print(PosMouse);
        curPosition = Camera.main.ScreenToWorldPoint(PosMouse);

    }
    void CameraMove()
    {
        tempCamera.y = MainCam.transform.position.y;
        tempCamera.x = transform.position.x;
        tempCamera.z = transform.position.z;
        MainCam.transform.position = tempCamera;
        CameraMiniMap.transform.position = tempCamera;
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);

    }
    public Vector3 PlayerGetPosition()
    {
        return transform.position;
    } 
    public Transform PlayerGetTransform()
    {
        return transform;
    }
}

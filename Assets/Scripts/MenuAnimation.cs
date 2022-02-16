using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public List<GameObject> ShipsPrefabs;
    public GameObject motherShip;
    float speed = 40;
    Vector3 startPositonF = new Vector3(43f, -131f, 228f);
    Vector3 startPositonMotherShip = new Vector3(-215f, -27f, -57f);
    Vector3 startPositonS = new Vector3(-102.4f, -131f,-23.2f);
    Vector3 endPositon = new Vector3(231f, -131f, 554f);
    Vector3 endPositonM = new Vector3(273.7f, -27.4f, 789.5f);

    void Start()
    {
        ShipsPrefabs[0].transform.position = startPositonF;
        ShipsPrefabs[1].transform.position = startPositonS;     
    }

    void MoveShips()
    {
        motherShip.transform.Translate(0, 0, Time.deltaTime * -speed);
        if (motherShip.transform.position.x > endPositonM.x && motherShip.transform.position.z > endPositonM.z)
        {
            motherShip.transform.position = startPositonMotherShip;
        }
        foreach (GameObject shipsRow in ShipsPrefabs)
        {
            shipsRow.transform.Translate(0,0,Time.deltaTime*speed);

            if (shipsRow.transform.position.x > endPositon.x && shipsRow.transform.position.z > endPositon.z)
            {
                shipsRow.transform.position = startPositonS;
            }
        }
        
    }

    void FixedUpdate()
    {
        MoveShips();
    }
}

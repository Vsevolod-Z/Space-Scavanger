using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNavigator : MonoBehaviour 
{
    public GameObject navCursor;

    AsteroidsSpawner asteroidsSpawner;
    RenderChangerStations renderChangerStations;

    Button buttonStation;
    Button buttonCluster;
    Button buttonOff;

    bool isFindStation, isFindCluster = false;
    [SerializeField]
    List<Vector3> ClustersPositions;
    [SerializeField]
    List<Vector3> StationsPositions;

    float nearestObjectDistance;
    float currentDistance;
    [SerializeField]
    Vector3 nearestPosition;
    Vector3 targetPos;

    void Start()
    {
        if (gameObject.layer == 8)
        {
            navCursor = GameObject.Find("NavCursor");
            buttonStation = GameObject.Find("Canvas/ButtonStationFind").gameObject.GetComponent<Button>();
            buttonStation.onClick.AddListener(FindStation);
            buttonCluster = GameObject.Find("Canvas/ButtonClusterFind").gameObject.GetComponent<Button>();
            buttonCluster.onClick.AddListener(FindCluster);
            buttonOff = GameObject.Find("Canvas/ButtonNavOff").gameObject.GetComponent<Button>();
            buttonOff.onClick.AddListener(CursorOff);

            asteroidsSpawner = FindObjectOfType<AsteroidsSpawner>();
            renderChangerStations = FindObjectOfType<RenderChangerStations>();
            ClustersPositions = asteroidsSpawner.GetClusterPositions();
            StationsPositions = renderChangerStations.GetStationsPositions();
        }
    }

    private void Update()
    {
        if (gameObject.layer == 8)
        {
            if (isFindCluster && !isFindStation)
            {
                if (!navCursor.activeInHierarchy)
                    navCursor.SetActive(true);
                FindNearestAsteroidCluster();
            }
            if (!isFindCluster && isFindStation)
            {
                if (!navCursor.activeInHierarchy)
                    navCursor.SetActive(true);
                FindNearestStation();
            }
            if (!isFindCluster && !isFindStation)
            {
                if (navCursor.activeInHierarchy)
                    navCursor.SetActive(false);
            }
        }
    }

    void PointTo(Vector3 point)
    {
        navCursor.transform.LookAt(point, Vector3.forward);
    }
    void FindStation()
    {
        isFindStation = true;
        isFindCluster = false;

    }
    void FindCluster()
    {

        isFindStation = false;
        isFindCluster = true;
    }

    void CursorOff()
    {
        isFindStation = false;
        isFindCluster = false;
    }

    void FindNearestStation()
    {

        nearestPosition = Vector3.zero;
        nearestObjectDistance = Mathf.Infinity;
        foreach (Vector3 stationPos in StationsPositions)
        {

            currentDistance = Vector3.Distance(transform.position, stationPos);
            if (currentDistance < nearestObjectDistance)
            {
                nearestPosition = stationPos;
                nearestObjectDistance = currentDistance;
            }
        }
        PointTo(nearestPosition);

    }
    void FindNearestAsteroidCluster()
    {

        nearestPosition = Vector3.zero;
        nearestObjectDistance = Mathf.Infinity;
        foreach (Vector3 clusterPos in ClustersPositions)
        {

            currentDistance = Vector3.Distance(transform.position, clusterPos);
            if (currentDistance < nearestObjectDistance)
            {
                nearestPosition = clusterPos;
                nearestObjectDistance = currentDistance;
            }
        }
        PointTo(nearestPosition);

    }

    
    /*public void Follow(Transform targetTransform, Rigidbody rg)
    {
        targetPos = targetTransform.position - transform.position;
        if (Vector3.Distance(targetTransform.position, transform.position) > playerRange)
        {
            rg.AddRelativeForce(0f, 0f, acceleration);
        }
        transform.forward = targetPos.normalized;
    }*/
}

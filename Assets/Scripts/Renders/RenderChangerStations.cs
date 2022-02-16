using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChangerStations : MonoBehaviour , IRenderer
{

    public List<Vector3> stationsPositions;
    public List<GameObject> stationsList;
    Player player;

    private void Start()
    {
       
        SetStationsPositions(stationsList);
        StartCoroutine(DelayedStart());
    }
    public IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(CheckRender());
        player = FindObjectOfType<Player>();

    }
    public IEnumerator CheckRender()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < stationsList.Count; i++)
        {
            if (Vector3.Distance(player.PlayerGetPosition(), stationsList[i].transform.position) > 1000)
            {

                stationsList[i].SetActive(false);

            }
            else
            {
                stationsList[i].SetActive(true);
            }
        }
        StartCoroutine(CheckRender());
    }

    void SetStationsPositions(List<GameObject> list)
    {
        foreach (GameObject stationGO in list)
        {
            stationsPositions.Add(stationGO.transform.position);
        }
    }
    public List<Vector3> GetStationsPositions()
    {
        return stationsPositions;
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour , ISpawner
{
    float min = -1500f;
    float max = 1500f;
    int index = 0;
    Vector3 temp;
    GameObject asteroid;
    List<GameObject> asteroids = new List<GameObject>();
    public List<GameObject> asteroidsPrefabs = new List<GameObject>();
    public List<GameObject> clustersList = new List<GameObject>();
    List<Transform> clustersTransform = new List<Transform>();
    List<Vector3> clustersPositions= new List<Vector3>();

    void Start()
    {
        SetTransforms(clustersList);
        SetPositions(clustersTransform);
        SpawnNewGame();
    }

    public void SpawnNewGame()
    {
        for (int i = 0; i < clustersList.Count; i++) 
        {
            for (int j = 0; j < 300; j++)
            {
                index = Random.Range(0, asteroidsPrefabs.Count);
                asteroid = Instantiate<GameObject>(asteroidsPrefabs[index],clustersTransform[i]);
                temp.y = 12;
                temp.z = Random.Range(min+clustersPositions[i].z, max + clustersPositions[i].z);
                temp.x = Random.Range(min + clustersPositions[i].x, max + clustersPositions[i].x);
                asteroid.transform.position = temp;
            }
        }
    }

    void SetTransforms(List<GameObject> list)
    {
        foreach (GameObject cluster in list)
        {
            clustersTransform.Add(cluster.transform);
        }
    }
    void SetPositions(List<Transform> list)
    {
        foreach (Transform clusterTransform in list)
        {
            clustersPositions.Add(clusterTransform.position);
        }
    }

    public List<Vector3> GetClusterPositions()
    {
        return clustersPositions;
    }
    public List<Transform> GetClusterTransforms()
    {
        return clustersTransform;
    }

    public void DeleteGO(GameObject GO)
    {
        asteroids.Remove(GO);
    }


}

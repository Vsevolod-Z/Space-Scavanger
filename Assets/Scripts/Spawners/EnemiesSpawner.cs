using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour, ISpawner
{
    [Header("Set in Inspector")]
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> enemiesPrefabs = new List<GameObject>();
    readonly int enemiesMaxCount=500;
    int index;
    Vector3 enemyPosition;
    void Start()
    {
        SpawnNewGame();
    }
    public void SpawnNewGame()
    {
        for (int i = 0; i < enemiesMaxCount; i++)
        {
            index = Random.Range(0, enemiesPrefabs.Count);    
            enemyPosition = new Vector3(Random.Range(-7500, 7500), 12, Random.Range(-7500, 7500));
            enemies.Add(Instantiate(enemiesPrefabs[index], enemyPosition, enemiesPrefabs[index].GetComponent<Rigidbody>().rotation));

        }
    }


    public void DeleteGO(GameObject GO)
    {
        enemies.Remove(GO);
    }

/*    public IEnumerator ESpawn()
    {

        yield return new WaitForSeconds(200f);
         while(enemies.Count < enemiesMaxCount)
        {
            index = Random.Range(0, enemiesPrefabs.Count);
            enemyPosition = new Vector3(Random.Range(-7500, 7500), 12, Random.Range(-7500, 7500));
            enemies.Add(Instantiate(enemiesPrefabs[index], enemyPosition, enemiesPrefabs[index].GetComponent<Rigidbody>().rotation));
        }
        StartCoroutine(ESpawn());
    }*/

    public List<GameObject> GetEnemiesList()
    {
        return enemies;
    }


}

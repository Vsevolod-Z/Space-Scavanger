using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChangerEnemies :MonoBehaviour, IRenderer
{
    [SerializeField]
    List<GameObject> enemiesShips;
    [SerializeField]
      List<Vector3> enemiesShipsPositions;
    EnemiesSpawner spawner;
    [SerializeField]
    Player player;
    private void Start()
    {
        spawner = gameObject.GetComponent<EnemiesSpawner>();
        enemiesShips = spawner.GetEnemiesList();
        StartCoroutine(DelayedStart());
        
    }

    public IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1f);
        player = FindObjectOfType<Player>();
        StartCoroutine(CheckRender());
       

    }

    public IEnumerator CheckRender()
    {
        enemiesShips = spawner.GetEnemiesList();
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < enemiesShips.Count; i++)
        {
            if (Vector3.Distance(player.PlayerGetPosition(), enemiesShips[i].transform.position) > 300)
            {
                foreach (GameObject enemy in enemiesShips)
                {

                    enemy.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            else
            {

                foreach (GameObject enemy in enemiesShips)
                {
                    enemy.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
       
    }

    public void RenderEnable(Transform GOtransform)
    {
        GOtransform.GetChild(0).gameObject.SetActive(true);
    }
    public void RenderDisable(Transform GOtransform)
    {
        GOtransform.GetChild(0).gameObject.SetActive(false);
    }
}

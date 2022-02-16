using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderChangerAsteroids :MonoBehaviour, IRenderer
{
    AsteroidsSpawner asteroidSpawner;

    List<Vector3> clustersPositions;

    List<Transform> clustersTransforms;

    Player player;

    private void Start()
    {
        asteroidSpawner = transform.GetComponent<AsteroidsSpawner>();
        clustersPositions = asteroidSpawner.GetClusterPositions();
        clustersTransforms = asteroidSpawner.GetClusterTransforms();

        StartCoroutine(DelayedStart());
    }

    public IEnumerator CheckRender()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < clustersPositions.Count; i++)
        {
            if (Vector3.Distance(player.PlayerGetPosition(), clustersPositions[i]) > 2000)
            {
                foreach (Transform child in clustersTransforms[i])
                {

                    child.gameObject.SetActive(false);
                }
            }
            else
            {

                foreach (Transform child in clustersTransforms[i])
                {
                    child.gameObject.SetActive(true);
                }
            }
        } 
        StartCoroutine(CheckRender());
    }
    public IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(CheckRender());
        player = FindObjectOfType<Player>();

    }
}

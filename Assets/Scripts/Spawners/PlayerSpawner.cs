using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour , ISpawner
{


    Vector3 playerPosition;

    Player player;

    Inventory playerInventory;

    PlayerHealthController playerHealthController;
    GameObject playerShip;

    public List<GameObject> playerShipsPrefabs = new List<GameObject>();

    private void Start()
    {
        SpawnNewGame();
    }
    public void SpawnNewGame()
    {
        playerPosition = new Vector3(0, 12, 0);
        playerShip = Instantiate<GameObject>(playerShipsPrefabs[0]);
        playerShip.transform.position = playerPosition;
    }

    public void DeleteGO(GameObject GO)
    {
      Destroy(gameObject);
    }

    /*public void SpawnLoadGame(GameObject playerGO , Vector3 playerPosition, float maxHealth , float currentHealth , int _maxWeight, float money, int goldAmount, int ironAmount, int crystallAmount, int titanAmount )
    {
        playerShip = Instantiate<GameObject>(playerGO);
        playerShip.transform.position = playerPosition;
        playerHealthController = playerShip.GetComponent<PlayerHealthController>();
        playerHealthController.MaxHealth = maxHealth;
        playerHealthController.Health = currentHealth;
        playerInventory = playerShip.GetComponent<Inventory>();
        playerInventory.maxWeight = _maxWeight;
        playerInventory.Money = money;
        playerInventory.Items[0] = goldAmount;
        playerInventory.Items[1] = ironAmount;
        playerInventory.Items[2] = crystallAmount;
        playerInventory.Items[3] = titanAmount;
    }*/
}

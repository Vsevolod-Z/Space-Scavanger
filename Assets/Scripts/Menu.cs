using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //GameObject playerGO, Vector3 playerPosition,
    static void Update()
    {
        if (Input.GetKey("escape"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                GoToMenu();
            }
        }
    }
    /* static void Save()
     {
         player = GameObject.FindGameObjectWithTag("Player");
         playerInventory = player.GetComponent<Inventory>();
         playerHealthController = player.GetComponent<PlayerHealthController>();

         PlayerPrefs.SetFloat("PlayerPosition.X", player.transform.position.x);
         PlayerPrefs.SetFloat("PlayerPosition.y", 12);
         PlayerPrefs.SetFloat("PlayerPosition.z", player.transform.position.z);

         PlayerPrefs.SetFloat("PlayerMaxHealth", playerHealthController.MaxHealth);
         PlayerPrefs.SetFloat("PlayerCurrentHealth", playerHealthController.Health);

         PlayerPrefs.SetFloat("PlayerMoney", playerInventory.Money);

         PlayerPrefs.SetInt("PlayerMaxWeight", playerInventory.maxWeight);

         PlayerPrefs.SetInt("PlayerGoldAmount", playerInventory.GetGoldAmount());
         PlayerPrefs.SetInt("PlayerIronAmount", playerInventory.GetIronAmount());
         PlayerPrefs.SetInt("PlayerCrystallAmount", playerInventory.GetCrystallAmount()) ;
         PlayerPrefs.SetInt("PlayerTitanAmount", playerInventory.GetTitanAmount());
         PlayerPrefs.Save();
     }*/
    /*  static void Load()
      {
          SceneManager.LoadScene(1);
          WaitUntilLoad();
          playerSpawner = GameObject.Find("Directional Light").GetComponent<PlayerSpawner>();

          Vector3 playerPosition = new Vector3(PlayerPrefs.GetFloat("PlayerPosition.X", player.transform.position.x), PlayerPrefs.GetFloat("PlayerPosition.y", 12), PlayerPrefs.GetFloat("PlayerPosition.z", player.transform.position.z));

          float maxHealth = PlayerPrefs.GetFloat("PlayerMaxHealth", playerHealthController.MaxHealth);
          float currentHealth = PlayerPrefs.GetFloat("PlayerCurrentHealth", playerHealthController.Health);
          float money = PlayerPrefs.GetFloat("PlayerMoney", playerInventory.Money);

          int maxWeight = PlayerPrefs.GetInt("PlayerMaxWeight", playerInventory.maxWeight);
          int goldAmount = PlayerPrefs.GetInt("PlayerGoldAmount", playerInventory.GetGoldAmount());
          int ironAmount = PlayerPrefs.GetInt("PlayerIronAmount", playerInventory.GetIronAmount());
          int crystallAmount = PlayerPrefs.GetInt("PlayerCrystallAmount", playerInventory.GetCrystallAmount());
          int titanAmount = PlayerPrefs.GetInt("PlayerTitanAmount", playerInventory.GetTitanAmount());

          playerSpawner.SpawnLoadGame(player, playerPosition, maxHealth, currentHealth, maxWeight, money, goldAmount, ironAmount, crystallAmount, titanAmount);


      }*/
    public static void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public static void NewGame()
    {

        SceneManager.LoadScene(1);
    }

    public static void Exit()
    {
        Application.Quit();
    }
}

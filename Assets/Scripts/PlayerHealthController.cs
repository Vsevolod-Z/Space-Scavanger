using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthController : MonoBehaviour , IHealthController
{
    [SerializeField]
    private float health;
    float maxHealth;
   public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public float Health { get { return health; } set { health = value; } }
    Slider healthSlider;
    TextMeshProUGUI textHealth;

    Player player;
    MessageCreator messageCreator;

    public GameObject Explosion;

    string message;

    void Start()
    {
        player = transform.GetComponent<Player>();
        healthSlider = GameObject.Find("Canvas/HealthBarGroup/healthSlider").gameObject.GetComponent<Slider>();
        textHealth = GameObject.Find("Canvas/HealthBarGroup/healthTextMeshPro").gameObject.GetComponent<TextMeshProUGUI>();

        messageCreator = FindObjectOfType<MessageCreator>();

        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;
        textHealth.text = health + "/" + maxHealth;
    }
    private void Update()
    {
        healthSlider.value = health;
        textHealth.text = health + "/" + maxHealth;
    }

    public void AddHealth(float heal)
    {
        health = health + heal;

    }
    public void AddHealth() 
    {
        health += maxHealth - health;
    }


    public void GetDamage(float damage)
    {

        if (health > 0)
        {
            if (health - damage < 0)
            {
                Instantiate(Explosion, transform.parent.GetComponent<Rigidbody>().position, transform.parent.GetComponent<Rigidbody>().rotation);
                player.GameOver();
            }
            health -= damage;
            //HealthValueChange(health);
        }
        if (health < 50)
        {
            message = "Critical ship integrity indicators - " + health + " !";
            StartCoroutine(messageCreator.CreateDangerWarning(message));
        }
        if (health <= 0)
        {
            Instantiate(Explosion, transform.GetComponent<Rigidbody>().position, transform.GetComponent<Rigidbody>().rotation);
            player.GameOver();
        }
    }
}

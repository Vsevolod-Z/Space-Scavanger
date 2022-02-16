using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour , IHealthController
{
    GameObject HPbar;
    GameObject HPbarBG;
    public GameObject Explosion;
    Vector3 HPbarTemp;
    AsteroidsSpawner asteroidsSpawner;
    EnemiesSpawner enemiesSpawner;
    private float health;

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        asteroidsSpawner = GameObject.Find("Directional Light").GetComponent<AsteroidsSpawner>();
        enemiesSpawner = GameObject.Find("Directional Light").GetComponent<EnemiesSpawner>();
        HPbar = gameObject.transform.Find("HPbar").gameObject;
        HPbarBG = gameObject.transform.Find("HPbarBG").gameObject;
        HPbarTemp.z = gameObject.transform.localScale.z;
        HPbarTemp.y = HPbar.transform.localScale.y;
        HPbarTemp.x = HPbar.transform.localScale.x;
        HPbar.SetActive(false);
        HPbarBG.SetActive(false);
    }

    void HealthChange(float currentHealth)
    {
        HPbarTemp.z = currentHealth / 10;
        if (HPbar != null && gameObject != null)
        {
            HPbar.transform.localScale = HPbarTemp;
        }
    }

    void SetActive()
    {
        HPbar.SetActive(true);
        HPbarBG.SetActive(true);
    }

    void Destroy()
    {

        Destroy(gameObject);
    }

    public void GetDamage(float damage)
    {

        if (health > 0)
        {
            health -= damage;
            HealthChange(health);

        }
        if (health < 100)
        {
            SetActive();
        }
        if (health <= 0)
        {
            if (transform.parent.tag == "Enemy")
            {
                Instantiate(Explosion, transform.parent.GetComponent<Rigidbody>().position, transform.parent.GetComponent<Rigidbody>().rotation);
                enemiesSpawner.DeleteGO(transform.parent.gameObject);
            }
            if (transform.parent.tag == "Asteroid")
            {
              asteroidsSpawner.DeleteGO(transform.parent.gameObject);
            }
            Destroy(transform.parent.gameObject);
            Destroy();
        }

    }
}

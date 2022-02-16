using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

 
public class Station : MonoBehaviour
{
    public GameObject panel;

    TradeSystem tradeSystem;

    float[] pricesBuy = new float[4];
    float[] pricesSell = new float[4];

    private void Start()
    {
        tradeSystem = GameObject.Find("Directional Light").GetComponent<TradeSystem>();
        SetRandomPrices();
    }

    void SetRandomPrices()
    {
        for (int i = 0; i < pricesBuy.Length; i++)
        {
            if (i < 2)
            {
                StartCoroutine(GeneratePrices(i, 1.5f, 2.3f));
            }
            else
            {
                StartCoroutine(GeneratePrices(i,2.5f, 3.5f));
            }

        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            tradeSystem.SetPrices(pricesBuy, pricesSell);
            panel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            panel.SetActive(false);

        }
    }

    IEnumerator GeneratePrices(int i, float min , float max)
    {
        if (gameObject.tag == "PirateStation")
        {
            min *= 1.4f; 
            max *= 1.4f;
        }
        yield return new WaitForFixedUpdate();
        while(pricesBuy[i] < pricesSell[i] || pricesBuy[i] == pricesSell[i])
        {
            pricesBuy[i] = Random.Range(min, max);
            pricesSell[i] = Random.Range(min, max);
        }
    }

}

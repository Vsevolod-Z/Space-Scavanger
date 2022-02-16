using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TradeSystem : MonoBehaviour
{
    enum TypyOfResource
    {
        Gold = 0 ,
        Iron = 1,
        Crystall = 2,
        Titan = 3
    }
    public GameObject panel;

    Inventory playerInventory;
    PlayerHealthController playerHealthController;

    Button sellGold;
    Button sellIronButton;
    Button sellCrystallButton;
    Button sellTitanButton;
    Button sellAllButton;

    Button buyGold;
    Button buyIronButton;
    Button buyCrystallButton;
    Button buyTitanButton;
    [SerializeField]
    Button buttonFixShip;

    Slider goldSlider;
    Slider ironSlider;
    Slider crystallSlider;
    Slider titanSlider;

    TextMeshProUGUI textGoldSlider;
    TextMeshProUGUI textIronSlider;
    TextMeshProUGUI textCrystallSlider;
    TextMeshProUGUI textTitanSlider;

    public TextMeshProUGUI[] pricesTextMeshProBuy = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] pricesTextMeshProSell = new TextMeshProUGUI[4];

    public TextMeshProUGUI[] sumsTextMeshProBuy = new TextMeshProUGUI[4];
    public TextMeshProUGUI[] sumsTextMeshProSell = new TextMeshProUGUI[4];

    public Slider[] sliders = new Slider[4];
    
    float[] pricesBuy = new float[4];
    float[] pricesSell = new float[4];

    // Start is called before the first frame update
    void Start()
    {
        

        textGoldSlider = GameObject.Find("Canvas/TradePanel/GoldCount").gameObject.GetComponent<TextMeshProUGUI>();
        textIronSlider = GameObject.Find("Canvas/TradePanel/IronCount").gameObject.GetComponent<TextMeshProUGUI>();
        textCrystallSlider = GameObject.Find("Canvas/TradePanel/CrystallCount").gameObject.GetComponent<TextMeshProUGUI>();
        textTitanSlider = GameObject.Find("Canvas/TradePanel/TitanCount").gameObject.GetComponent<TextMeshProUGUI>();

        goldSlider = GameObject.Find("Canvas/TradePanel/sliderGold").gameObject.GetComponent<Slider>();
        ironSlider = GameObject.Find("Canvas/TradePanel/sliderIron").gameObject.GetComponent<Slider>();
        crystallSlider = GameObject.Find("Canvas/TradePanel/sliderCrystall").gameObject.GetComponent<Slider>();
        titanSlider = GameObject.Find("Canvas/TradePanel/sliderTitan").gameObject.GetComponent<Slider>();

        buyGold = GameObject.Find("Canvas/TradePanel/ButtonBuyGold").gameObject.GetComponent<Button>();
        buyGold.onClick.AddListener(BuyGold);
        buyIronButton = GameObject.Find("Canvas/TradePanel/ButtonBuyIron").gameObject.GetComponent<Button>();
        buyIronButton.onClick.AddListener(BuyIron);
        buyCrystallButton = GameObject.Find("Canvas/TradePanel/ButtonBuyCrystall").gameObject.GetComponent<Button>();
        buyCrystallButton.onClick.AddListener(BuyCrystall);
        buyTitanButton = GameObject.Find("Canvas/TradePanel/ButtonBuyTitan").gameObject.GetComponent<Button>();
        buyTitanButton.onClick.AddListener(BuyTitan);

        sellGold = GameObject.Find("Canvas/TradePanel/ButtonSellGold").gameObject.GetComponent<Button>();
        sellGold.onClick.AddListener(SellGold);
        sellIronButton = GameObject.Find("Canvas/TradePanel/ButtonSellIron").gameObject.GetComponent<Button>();
        sellIronButton.onClick.AddListener(SellIron);
        sellCrystallButton = GameObject.Find("Canvas/TradePanel/ButtonSellCrystall").gameObject.GetComponent<Button>();
        sellCrystallButton.onClick.AddListener(SellCrystall);
        sellTitanButton = GameObject.Find("Canvas/TradePanel/ButtonSellTitan").gameObject.GetComponent<Button>();
        sellTitanButton.onClick.AddListener(SellTitan);
        sellAllButton = GameObject.Find("Canvas/TradePanel/ButtonSellAll").gameObject.GetComponent<Button>();
        sellAllButton.onClick.AddListener(SellAll);
        
        buttonFixShip = GameObject.Find("Canvas/TradePanel/FixShipButton").gameObject.GetComponent<Button>();
        buttonFixShip.onClick.AddListener(FixShip);
        
        panel.SetActive(false);
        StartCoroutine(DelayedStart());
    }
    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1f);
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerHealthController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthController>();
    }
    private void Update()
    {
        textGoldSlider.text = ((int)goldSlider.value).ToString();
        textIronSlider.text = ((int)ironSlider.value).ToString();
        textCrystallSlider.text = ((int)crystallSlider.value).ToString();
        textTitanSlider.text = ((int)titanSlider.value).ToString();
        for(int i = 0; i< sumsTextMeshProBuy.Length;i++)
        {
            sumsTextMeshProBuy[i].text = string.Format("{0:0.00}", pricesBuy[i]* (int)sliders[i].value);
            sumsTextMeshProSell[i].text = string.Format("{0:0.00}", pricesSell[i]*(int)sliders[i].value);
        }
        
    }
    

    void SellGold()
    {
        playerInventory.SellResource(0, (int)goldSlider.value, pricesSell[0] * goldSlider.value);

    }
    void SellIron()
    {
        playerInventory.SellResource(1, (int)ironSlider.value, pricesSell[1] * ironSlider.value);
    }
    void SellCrystall()
    {
        playerInventory.SellResource(2, (int)crystallSlider.value, pricesSell[2] * crystallSlider.value);
    }
    void SellTitan()
    {
        playerInventory.SellResource(3, (int)titanSlider.value, pricesSell[3] * titanSlider.value);
    }
    void SellAll()
    {
        for (int i = 0; i < pricesSell.Length; i++)
        {
            playerInventory.SellResource(i, playerInventory.maxNumOfResources, pricesSell[i] * 250);
        }
    }

    void BuyGold()
    {
        playerInventory.BuyResource(0, (int)goldSlider.value, pricesBuy[0] * goldSlider.value);
    }
    void BuyIron()
    {
        playerInventory.BuyResource(1, (int)ironSlider.value, pricesBuy[1] * ironSlider.value);

    }
    void BuyCrystall()
    {
        playerInventory.BuyResource(2, (int)crystallSlider.value, pricesBuy[2] * crystallSlider.value);
    }
    void BuyTitan()
    {
        playerInventory.BuyResource(3, (int)titanSlider.value, pricesBuy[3] * titanSlider.value);
    }

    public void SetPrices(float[] stationPricesBuy, float[] stationPricesSell)
    {
        for (int i = 0; i < pricesBuy.Length; i++)
        {
            pricesBuy[i] = stationPricesBuy[i];
            pricesSell[i] = stationPricesSell[i];
        }

        for (int i = 0; i < pricesTextMeshProBuy.Length; i++)
        {
            pricesTextMeshProBuy[i].text = string.Format("{0:0.00}", pricesBuy[i]);
            pricesTextMeshProSell[i].text = string.Format("{0:0.00}", pricesSell[i]);
        }
    }

    void FixShip()
    {
        if (playerHealthController.Health < 200)
        {
            if (playerInventory.ReduceMoney(500f))
            {
                if ((int)(playerHealthController.Health + 50f) <= 200)
                    playerHealthController.AddHealth(50f);
                else
                    playerHealthController.AddHealth();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    [SerializeField]
    float money, weight, sum;

    public int maxWeight = 1000;
    public int maxNumOfResources = 250;
    Slider goldSlider;
    Slider ironSlider;
    Slider crystallSlider;
    Slider titanSlider;
    Slider weightSlider;
    TextMeshProUGUI textMoney;
    TextMeshProUGUI textWeight;

    MessageCreator messageCreator;

    string message;

    public float Money { get { return money; } set { money = value; } }

    public int[] Items;


    void Start()
    {
        goldSlider = GameObject.Find("Canvas/SliderGoldGroup/sliderGold").gameObject.GetComponent<Slider>();
        ironSlider = GameObject.Find("Canvas/SliderIronGroup/sliderIron").gameObject.GetComponent<Slider>();
        crystallSlider = GameObject.Find("Canvas/SliderCrystallGroup/sliderCrystall").gameObject.GetComponent<Slider>();
        titanSlider = GameObject.Find("Canvas/SliderTitanGroup/sliderTitan").gameObject.GetComponent<Slider>();
        weightSlider = GameObject.Find("Canvas/WeightIndicatorGroup/weightSlider").gameObject.GetComponent<Slider>();

        textMoney = GameObject.Find("Canvas/MoneyTextMeshPro").gameObject.GetComponent<TextMeshProUGUI>();

        textWeight = GameObject.Find("Canvas/WeightIndicatorGroup/weightTextMeshPro").gameObject.GetComponent<TextMeshProUGUI>();

        messageCreator = FindObjectOfType<MessageCreator>();

        weightSlider.maxValue = maxWeight;
        Items = new int[5] { 0, 0, 0, 0, 0 };
        Money = 1000f;
        UpdateInventoryHUD();
    }
    private void Update()
    {
        UpdateInventoryHUD();
    }
    public void UpdateInventoryHUD()
    {
        UpdateResourceSliders();
        UpdateMoney();
        UpdateWeight();

    }
    public void SellResource(int index, int quantity, float price)
    {

        if (Items[index] - quantity >= 0)
        {

            Items[index] -= quantity;
            money += price;
            message = string.Format("{0:0.00}$ Has been credited to your account!", price);
            StartCoroutine(messageCreator.CreateNotification(message));
            // вывод сообщения о начислении средств
        }
        else
        {
            message = "Lack of resources!";
            StartCoroutine(messageCreator.CreateWarning(message));
            //вывод сообщения о недостаче ресурса
        }
        UpdateInventoryHUD();
    }
    public void BuyResource(int index, int quantity, float price)
    {
        if (Items[index] + quantity <= maxNumOfResources)
        {
            if (money - price >= 0)
            {
                Items[index] += quantity;
                money -= price;
                message = string.Format("{0:0.00}$ Has been withdrawn from your account!", price);
                StartCoroutine(messageCreator.CreateNotification(message));
            }
            else
            {
                message = string.Format("Insufficient funds - {0:0.00} ", Mathf.Abs(money - price));
                StartCoroutine(messageCreator.CreateWarning(message));
                //вывод сообщения о нехватке средстве
            }
        }
        else
        {
            message = "Your inventory is full!";
            StartCoroutine(messageCreator.CreateWarning(message));
            //вывод сообщения о переполнении инвентаря
        }
        UpdateInventoryHUD();
    }
    public void AddResource(int index, int quantity)
    {
        if (Items[index] + quantity <= maxNumOfResources)
        {
            Items[index] += quantity;
        }
        else if (Items[index] + quantity > maxNumOfResources)
        {
            Items[index] = maxNumOfResources;
            message = "Lack of resources!";
            StartCoroutine(messageCreator.CreateWarning(message));
        }
        UpdateInventoryHUD();
    }

    public int GetGoldAmount()
    {
        return Items[0];
    }
    public int GetIronAmount()
    {
        return Items[1];
    }
    public int GetCrystallAmount()
    {
        return Items[2];
    }
    public int GetTitanAmount()
    {
        return Items[3];
    }

    void UpdateResourceSliders()
    {
        goldSlider.value = Items[0];
        ironSlider.value = Items[1];
        crystallSlider.value = Items[2];
        titanSlider.value = Items[3];
    }
    void UpdateWeight()
    {
        for (int i = 0; i < Items.Length - 1; i++)
            sum += Items[i];
        weight = sum;
        weightSlider.value = (int)weight;
        textWeight.text = (int)weight + "/" + maxWeight;
        sum = 0;

    }
    void UpdateMoney()
    {

        StartCoroutine(messageCreator.CreateNotification(message));
        textMoney.text = string.Format("{0:0.00}$", money);
    }
    public bool ReduceMoney(float price)
    {
        bool isOperationComplete = false;
        if( Money - price >= 0)
        {
           Money -= price;
            isOperationComplete = true;
        }
        if (Money - price < 0)
        {
            isOperationComplete = false;
        }
        return isOperationComplete;
    }
}
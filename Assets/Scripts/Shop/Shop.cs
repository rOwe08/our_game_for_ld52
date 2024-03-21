using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static string[] items = new string[5] { "Cabbage", "Carrot", "Tomato", "Potato", "Mushrooms" };
    public AudioSource SoundBuy;

    public static Dictionary<string, int> shopItemsPricesDict = new Dictionary<string, int>
    {
        {"Cabbage", 50 },
        {"Carrot", 20 },
        {"Tomato", 30 },
        {"Potato", 15 },
        {"Mushrooms", 30 },
    };
    public static Dictionary<string, int> shopItemsCountDict = new Dictionary<string, int>
    {
        {"Cabbage", 0 },
        {"Carrot", 0 },
        {"Tomato", 0 },
        {"Potato", 0 },
        {"Mushrooms", 0 },
    };
    [Serializable] class ShopItem
    {
        public Sprite Image;
        public Text text;
        public bool IsPurchased = false;
        public int Price;
    }
    public static Shop shop;
    [SerializeField] List<ShopItem> shopItemsList;
    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;

    void Update()
    {
        for (int i = 0; i < shopItemsList.Count; i++)
        {
            PriceCountUpdate(i);
            SetMode(i);
        }
    }
    void Start()
    {
        shop = this;
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = shopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = shopItemsList[i].Image;
            g.transform.GetChild(1).gameObject.GetComponent<Text>().text = $"Price: {Convert.ToString(shopItemsPricesDict[items[i]])}";
            g.transform.GetChild(2).gameObject.GetComponent<Text>().text = $"Available: {Convert.ToString(shopItemsCountDict[items[i]])}";
            g.transform.GetChild(3).GetComponent<Button>().interactable = !shopItemsList[i].IsPurchased;

            buyBtn = g.transform.GetChild(3).GetComponent<Button>();
            buyBtn.interactable = !shopItemsList[i].IsPurchased;
            buyBtn.AddEventListener(i, OnShopitemBtnClicked);
        }

        Destroy(ItemTemplate);
    }
    public void ShopUpdate()
    {
        int len = items.Length;
        for (int i = 0; i < len; i++)
        {
            SetMode(i);
        }
    }
    public void SetMode(int itemIndex)
    {
        if (BalanceManager.Instance.CheckOnMinusCoins(shopItemsPricesDict[items[itemIndex]]) || shopItemsCountDict[items[itemIndex]] == 0)
        {
            shopItemsList[itemIndex].IsPurchased = true;
            ShopScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = false;
        }
        else
        {
            shopItemsList[itemIndex].IsPurchased = false;
            ShopScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = true;
        }
    }
    public void PriceCountUpdate(int i)
    {
        ShopScrollView.GetChild(i).GetChild(1).GetComponent<Text>().text = $"Price: {Convert.ToString(shopItemsPricesDict[items[i]])}";
        ShopScrollView.GetChild(i).GetChild(2).GetComponent<Text>().text = $"Available: {Convert.ToString(shopItemsCountDict[items[i]])}";
    }
    void OnShopitemBtnClicked(int itemIndex)
    {
        if (!BalanceManager.Instance.CheckOnMinusCoins(shopItemsPricesDict[items[itemIndex]]) && shopItemsCountDict[items[itemIndex]] != 0)
        {
            SoundBuy.Play();
            shopItemsList[itemIndex].IsPurchased = true;
            shopItemsCountDict[items[itemIndex]]--;

            ShopScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = false;
            SeedInvent.PlusItemToSeedInvent(itemIndex);

            BalanceManager.Instance.MinusCoins(shopItemsPricesDict[items[itemIndex]]);
            PriceCountUpdate(itemIndex);
        }
    }
}

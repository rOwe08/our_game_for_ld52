using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour
{

    public static string[] items = new string[5] { "Cabbage", "Carrot", "Tomato", "Potato", "Mushrooms" };
    public static double xMultiCab = 1.5;
    public static double xMultiCar = 1.3;
    public static double xMultiTom = 1.4;
    public static double xMultiPot = 1.3;
    public static double xMultiMush = 1.4;

    public static Dictionary<string, int> inventoryItemsCountDict = new Dictionary<string, int>
    {
        {"Cabbage", 0 },
        {"Carrot", 0 },
        {"Tomato", 0 },
        {"Potato", 0 },
        {"Mushrooms", 0 },
    };

    public static Dictionary<string, int> inventoryItemsPricesDict = new Dictionary<string, int>
    {
        {"Cabbage", (int)(50 * xMultiCab)},
        {"Carrot", (int)(20 * xMultiCar)},
        {"Tomato", (int)(30 * xMultiTom)},
        {"Potato", (int)(15 * xMultiPot)},
        {"Mushrooms", (int)(30 * xMultiMush)},
    };
    [System.Serializable] class inventoryItem
    {
        public Sprite Image;
        public Text text;
        public bool IsSold = false;
        public int price;
    }
    public static Inventory inventory;
    [SerializeField] List<inventoryItem> inventoryItemsList;
    public int lenOfSeeds = 5;
    public AudioSource SoundSell;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField] public Transform InventoryScrollView;
    Button sellBtn;

    void Start()
    {
        inventory = this;
        ItemTemplate = InventoryScrollView.GetChild(0).gameObject;

        int len = inventoryItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, InventoryScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = inventoryItemsList[i].Image;
            g.transform.GetChild(1).gameObject.GetComponent<Text>().text = $"Price: {Convert.ToString(inventoryItemsPricesDict[items[i]])}";
            g.transform.GetChild(2).gameObject.GetComponent<Text>().text = $"Available: {Convert.ToString(inventoryItemsCountDict[items[i]])}";
            g.transform.GetChild(3).GetComponent<Button>().interactable = true;

            sellBtn = g.transform.GetChild(3).GetComponent<Button>();
            sellBtn.interactable = true;

            sellBtn.AddEventListener(i, OnInventoryitemBtnClicked);
        }
        
        Destroy(ItemTemplate);
    }
    void Update()
    {
        InventoryUpdate();
    }
    public void InventoryUpdate()
    {
        int len = items.Length;
        for (int i = 0; i < len; i++)
        {
            SetMode(i);
        }
    }
    public void PlusItemToInventory(int index)
    {
        inventoryItemsCountDict[items[index]]++;
        SetMode(index);
    }
    public void PriceCountUpdate(int i)
    {
        InventoryScrollView.GetChild(i).GetChild(1).GetComponent<Text>().text = $"Price: {Convert.ToString(inventoryItemsPricesDict[items[i]])}";
        InventoryScrollView.GetChild(i).GetChild(2).GetComponent<Text>().text = $"Available: {Convert.ToString(inventoryItemsCountDict[items[i]])}";
    }
    public void SetMode(int itemIndex)
    {
        if (inventoryItemsCountDict[items[itemIndex]] != 0)
        {
            inventoryItemsList[itemIndex].IsSold = false;
            PriceCountUpdate(itemIndex);
            InventoryScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = true;
        }
        else
        {
            inventoryItemsList[itemIndex].IsSold = true;
            PriceCountUpdate(itemIndex);
            InventoryScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = false;
        }
    }
    void OnInventoryitemBtnClicked(int itemIndex)
    {

        if (inventoryItemsCountDict[items[itemIndex]] != 0)
        {
            inventoryItemsList[itemIndex].IsSold = false;
            SoundSell.Play();
            PriceCountUpdate(itemIndex);
            InventoryScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = true;

            BalanceManager.Instance.PlusCoins(inventoryItemsPricesDict[items[itemIndex]]);

            inventoryItemsCountDict[items[itemIndex]]--;
        }
        else
        {
            PriceCountUpdate(itemIndex);
            InventoryScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = false;
        }

        if (inventoryItemsCountDict[items[itemIndex]] != 0)
        {
            inventoryItemsList[itemIndex].IsSold = false;
            PriceCountUpdate(itemIndex);
            InventoryScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = true;
        }
        else
        {   
            inventoryItemsList[itemIndex].IsSold = true;
            InventoryScrollView.GetChild(itemIndex).GetChild(1).GetComponent<Text>().text = $"Price: {Convert.ToString(inventoryItemsPricesDict[items[itemIndex]])}";
            InventoryScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Text>().text = $"Available: {Convert.ToString(inventoryItemsCountDict[items[itemIndex]])}";
            InventoryScrollView.GetChild(itemIndex).GetChild(3).GetComponent<Button>().interactable = false;
        }
    }
}

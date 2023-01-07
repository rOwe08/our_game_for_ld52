using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem
    {
        public Sprite Image;
        public bool IsPurchased = false;
    }

    [SerializeField] List<ShopItem> ShopItemsList;

    GameObject ItemTemplate;
    GameObject g;
    [SerializeField]Transform ShopScrollView;
    Button buyBtn;


    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = ShopItemsList.Count;
        for (int i = 0; i <len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild (0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetComponent<Button>().interactable = !ShopItemsList[i].IsPurchased;
            buyBtn = g.transform.GetChild(1).GetComponent<Button>();
            buyBtn.interactable = !ShopItemsList[i].IsPurchased;
            buyBtn.AddEventListener(i, OnShopitemBtnClicked);
        }

        Destroy(ItemTemplate);
    }

    void OnShopitemBtnClicked(int itemIndex)
    {
        ShopItemsList[itemIndex].IsPurchased = true;

        ShopScrollView.GetChild(itemIndex).GetChild(1).GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        
    }
}

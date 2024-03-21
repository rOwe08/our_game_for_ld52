using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BalanceManager Instance;
    public GameObject shopWindow;
    public GameObject strangersWindow;
    public GameObject quitWindow;
    public static int coins = 100;
    public static int startCoins = 100;
    public static int countOfItems = 5;
    public static bool isActiveWindow = false;

    public void Start()
    {
        instance = this;
    }
    public void PauseGame()
    {
        quitWindow.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void QuitOff()
    {
        quitWindow.SetActive(false);
    }
    public void MeetStrangers()
    {
        if (!Player.FarmIsActive)
        {
            strangersWindow.SetActive(true);
            isActiveWindow = true;
        }
    }
    public void OffStrangers()
    {
        strangersWindow.SetActive(false);
        isActiveWindow = false;
    }
    public void MeetTheShop()
    {
        if (!Player.FarmIsActive && !isActiveWindow)
        {
            var rand = new System.Random();
            for (int i = 0; i < countOfItems; i++)
            {
                int countItem = rand.Next(0, 5);
                Shop.shopItemsCountDict[Shop.items[i]] = countItem;
            }

            shopWindow.SetActive(true);
            isActiveWindow = true;
        }
    }
    public void SetOffTriggerShop()
    {
        TriggerShop.endTrigger = true;
        TriggerShop.enterTrigger = false;
    }
    public void SetOffTriggerStrangers()
    {
        TriggerStrangers.endTrigger = true;
        TriggerStrangers.enterTrigger = false;
    }
    public void ShopOff()
    {
        var rand = new System.Random();
        for (int i = 0; i < countOfItems; i++)
        {
            int countItem = rand.Next(0, 5);
            Shop.shopItemsCountDict[Shop.items[i]] = countItem;
        }
        shopWindow.SetActive(false);
        isActiveWindow = false;
    }

    public void StartNewGame()
    {
        coins = startCoins;
        PlayerPrefs.SetInt("Coins", coins);
    }
    public void UploadGame()
    {
        coins = PlayerPrefs.GetInt("Coins", coins);
    }
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}

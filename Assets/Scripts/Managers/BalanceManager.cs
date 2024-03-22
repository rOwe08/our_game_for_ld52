using System;
using UnityEngine;
using TMPro;

public class BalanceManager : MonoBehaviour
{
    public static BalanceManager Instance { get; set; }
    [SerializeField] private TextMeshProUGUI coinsShopText;
    [SerializeField] private TextMeshProUGUI coinsInventoryText;
    [SerializeField] private TextMeshProUGUI coinsMainText;
    public int coins = 100;

    public void Start()
    {
        Instance = this;
        this.coins = GameManager.coins;
        SetBalanceTexts();
    }
    public void SetCoins(int coins)
    {
        this.coins += coins;
        SetBalanceTexts();
    }
    public void SaveCoins()
    {
        coins = Instance.coins;
        PlayerPrefs.SetInt("Coins", coins);
    }
    public void MinusCoins(int coins)
    {
        this.coins -= coins;
        SetBalanceTexts();
    }
    public void PlusCoins(int coins)
    {
        this.coins += coins;
        SetBalanceTexts();
    }
    private void SetBalanceTexts()
    {
        coinsShopText.text = "Balance: " + this.coins;
        coinsInventoryText.text = "Balance: " + this.coins;
        coinsMainText.text = "Balance: " + this.coins;
    }
    public bool CheckOnMinusCoins(double coins) => this.coins - coins < 0;
}

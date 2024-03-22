using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class FuelManager : MonoBehaviour
{
    public float fuel = 100f;
    private float decreaseRate = 1f;
    public TextMeshProUGUI fuelText;

    void Start()
    {
        StartCoroutine(DecreaseFuelOverTime());
    }

    IEnumerator DecreaseFuelOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (Time.timeScale != 0)
            {
                fuel -= decreaseRate;
                UpdateUI();
            }
        }
    }
    private void UpdateUI()
    {
        fuelText.text = "Fuel: " + Convert.ToString(fuel);
    }
}

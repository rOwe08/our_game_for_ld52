using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int days = 0;
    private float increaseDelta = 100;
    private int increaseRate = 1;
    public TextMeshProUGUI dayText;

    void Start()
    {
        StartCoroutine(IncreaseDaysOverTime());
    }

    IEnumerator IncreaseDaysOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseDelta);
            days += increaseRate;
            Debug.Log("Days increased to: " + days);
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        dayText.text = "Days: " + Convert.ToString(days);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SeedInvent : MonoBehaviour
{
    public static string[] items = new string[5] { "Cabbage", "Carrot", "Tomato", "Potato", "Mushrooms" };
    public static Dictionary<string, int> seedInventItemsCountDict = new Dictionary<string, int>
    {
        {"Cabbage", 0 },
        {"Carrot", 0 },
        {"Tomato", 0 },
        {"Potato", 0 },
        {"Mushrooms", 0 },
    };
    public static void PlusItemToSeedInvent(int index)
    {
        seedInventItemsCountDict[items[index]]++;
    }
}

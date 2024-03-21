using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShop : MonoBehaviour
{
    public static bool enterTrigger = false;
    public static bool endTrigger = false;
    public static int number = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            enterTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        endTrigger = false;
    }
}


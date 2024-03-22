using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject quitWindow;
    public GameObject farmWindow;
    public float speed = 3f;
    public static bool FarmIsActive = false;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitWindow.SetActive(true);
            PauseController.PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !GameManager.isActiveWindow)
        {
            if (FarmIsActive)
            {   
                farmWindow.SetActive(false);
                FarmIsActive = false;
                PauseController.ResumeGame();
            }
            else
            {
                farmWindow.SetActive(true);
                FarmIsActive = true;
                PauseController.PauseGame();
            }
        }

        if (TriggerShop.enterTrigger is true && TriggerShop.endTrigger is not true)
        {
            GameManager.instance.MeetTheShop();
            PauseController.PauseGame();
        }
        if (TriggerStrangers.enterTrigger is true && TriggerStrangers.endTrigger is not true)
        {
            GameManager.instance.MeetStrangers();
            PauseController.PauseGame();
        }
    }

}


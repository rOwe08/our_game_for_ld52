using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class TileScript : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    private int currentProgression = 0;
    public int timeBetweenGrowths;
    public int maxGrowth;
    public AudioSource SoundPlanting;
    public AudioSource SoundPicking;

    private string[] farmingTile = new string[9];
    void Start()
    {
        InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && currentProgression == 0)
        {
            string nameTemp = DragAndDropScript.nameOfObject;
            if (SeedInvent.seedInventItemsCountDict[nameTemp] != 0)
            {
                SoundPlanting.Play();
                farmingTile[Convert.ToInt32(gameObject.name)] = nameTemp;
                currentProgression++;
                gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true);
                SeedInvent.seedInventItemsCountDict[nameTemp]--;
                DragAndDropScript.UpdateFarm();
            }
        }
    }
        
    public void Growth()
    {
        if (currentProgression == maxGrowth)
        {
            gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true);
            isReadyScript.isReady = true;
        }
        if (currentProgression < maxGrowth && currentProgression != 0)
        {
            currentProgression++;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (currentProgression == maxGrowth)
        {
            SoundPicking.Play();
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            currentProgression = 0;
            isReadyScript.isReady = false;
            int key = int.Parse(gameObject.name);
            Inventory.inventoryItemsCountDict[farmingTile[key]]++;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    private int currentProgression = 0;
    public int timeBetweenGrowths;
    public int maxGrowth;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && currentProgression == 0)
        {
            currentProgression ++;
            gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true);
        }
    }
        

    void Start()
    {
        InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
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
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            currentProgression = 0;
            isReadyScript.isReady = false;
        }
    }


}

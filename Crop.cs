using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Crop : MonoBehaviour
{

  private int currentProgression = 0;
  public int timeBetweenGrowths;
  public int maxGrowth;

  void Start() {
    InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
  }

  void Update(){
  }

  public void Growth(){
    
    if (currentProgression != maxGrowth) {
      gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true);
    }
    if (currentProgression > 0 && currentProgression < maxGrowth){
      gameObject.transform.GetChild(currentProgression-1).gameObject.SetActive(false);
    }
    if (currentProgression < maxGrowth){
      currentProgression++;
    }

  }

}

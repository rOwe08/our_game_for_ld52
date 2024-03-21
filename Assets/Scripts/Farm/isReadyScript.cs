using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isReadyScript : MonoBehaviour
{
    public GameObject myobject;
    public static bool isReady = false;

    void Update()
    {
       myobject.SetActive(isReady);
    }
}

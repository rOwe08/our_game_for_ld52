using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelRotation : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * -650f));
    }
}

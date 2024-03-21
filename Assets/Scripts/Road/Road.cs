using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float speed = 3f;
    private float leftEdge;
    public void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10f;
    }
    public void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}

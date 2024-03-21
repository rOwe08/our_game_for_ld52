using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomGround : MonoBehaviour
{
    public float speed = 2f;
    private float leftEdge;
    public void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 20f;
    }
    public void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}

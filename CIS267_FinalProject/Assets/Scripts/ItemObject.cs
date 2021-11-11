using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;
    [Range(0.0f, 1.0f)]
    public float amplitude;
    [Range(0.0f, 5f)]
    public float frequncy;
    private float originalY;
    //private void Update()
    //{
    //    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    //    if (rb.velocity.magnitude > .5)
    //    {
    //        rb.velocity = -rb.velocity / 2;
    //    } 
    //    else if (rb.velocity.magnitude <= 0f)
    //    {
    //        rb.velocity = Vector2.zero;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    GetComponent<Rigidbody2D>().position = GetComponent<Rigidbody2D>().position * Mathf.Cos(Time.time);
    //}

    private void Start()
    {
        this.originalY = GetComponent<Rigidbody2D>().position.y;
    }

    private void Update()
    {
        GetComponent<Rigidbody2D>().position = new Vector2(transform.position.x,
    originalY + (Mathf.Sin(frequncy*Time.time) * amplitude));
    }
}

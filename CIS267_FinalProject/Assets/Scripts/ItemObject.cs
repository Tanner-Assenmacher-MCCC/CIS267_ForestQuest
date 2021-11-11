using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item;
    private Rigidbody2D rb;
    [Range(0.0f, 1.0f)]
    public float amplitude;
    [Range(0.0f, 5f)]
    public float frequncy;
    private float originalY;
    public bool shouldFloat = true;   

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.originalY = rb.position.y;
    }

    private void Update()
    {
        if (shouldFloat && rb.velocity.y == 0)
        {
            rb.position = new Vector2(transform.position.x, originalY + (Mathf.Sin(frequncy * Time.time) * amplitude));
        }
    }
}

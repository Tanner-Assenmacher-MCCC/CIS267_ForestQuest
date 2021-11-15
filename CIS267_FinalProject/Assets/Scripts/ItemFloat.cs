using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloat : MonoBehaviour
{
    private Rigidbody2D rb;
    [Range(0.0f, 1.0f)]
    public float amplitude;
    [Range(0.0f, 5f)]
    public float frequncy;
    public bool shouldFloat = true;
    private float positionY;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        positionY = gameObject.transform.position.y;
        if (!shouldFloat)
        {
            rb.position = new Vector2(transform.position.x, ((Mathf.Sin(frequncy * Time.time) * amplitude)) / 10);
            shouldFloat = true;
        }

        if (shouldFloat && rb.velocity.y == 0)
        {
            rb.position = new Vector2(transform.position.x, positionY + ((Mathf.Sin(frequncy * Time.time) * amplitude)) / 15);
        }
    }
}

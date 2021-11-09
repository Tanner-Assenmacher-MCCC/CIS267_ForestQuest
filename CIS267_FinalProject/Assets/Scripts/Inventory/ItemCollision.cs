using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Item Collision");
        if (collision.CompareTag("Item"))
        {
            if (Inventory.instance.Add(collision.gameObject.GetComponent<ItemObject>().item)) Destroy(collision.gameObject);
        }
    }
}

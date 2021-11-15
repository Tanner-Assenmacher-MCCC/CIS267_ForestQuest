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
            Item item = collision.gameObject.GetComponent<ItemObject>().item;
            if (Hotbar.instance.Add(item))
            {
                Destroy(collision.gameObject);
            }
            else if (Inventory.instance.Add(item))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

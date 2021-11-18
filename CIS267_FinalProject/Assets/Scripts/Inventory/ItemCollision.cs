using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    bool firstItem = true;
    public WeaponHolster wp;
    public Player p;

    private void Start()
    {
        wp = FindObjectOfType<WeaponHolster>();
        p = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.gameObject.GetComponent<ItemObject>().item;
            if (Hotbar.instance.items.Count == 0)
            {
                firstItem = true;
            }
            else
            {
                firstItem = false;
            }
            if (Hotbar.instance.Add(item))
            {
                Destroy(collision.gameObject);
                if (firstItem)
                {
                    Hotbar.instance.HighlightButton(0);
                    p.UseItem(item);
                }
            }
            else if (Inventory.instance.Add(item))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

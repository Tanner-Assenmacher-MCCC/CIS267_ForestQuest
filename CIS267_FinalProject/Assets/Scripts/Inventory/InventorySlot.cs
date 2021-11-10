using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject slotObject;
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addItem(Item newItem)
    {
        
        item = newItem;
        slotObject.GetComponent<SpriteRenderer>().sprite = item.sprite;
        slotObject.gameObject.SetActive(true);
    }

    public void clearSlot()
    {
       
        item = null;
        slotObject.GetComponent<SpriteRenderer>().sprite = null;
        slotObject.SetActive(false);
    }

    public void removeItem()
    {
        Inventory.instance.Remove(item);
    }
}

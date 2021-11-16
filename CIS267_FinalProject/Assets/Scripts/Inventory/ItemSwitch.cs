using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwitch : MonoBehaviour
{
    public Hotbar hb;
    public HotbarUI hbUI;
    public Inventory inventory;
    public InventoryUI inventoryUI;

    public Item hotbarItem;
    public Item inventoryItem;
    public int hotbarIndex;
    public int inventoryIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHotBarItem(int i)
    {
        hotbarItem = Hotbar.instance.items[i];
        hotbarIndex = i;
        SwitchItems();
        Debug.Log("hotbar item: " + hotbarItem + "  inventory item: " + inventoryItem);
    }

    public void setInventoryItem(int i)
    {
        inventoryItem = Inventory.instance.items[i];
        inventoryIndex = i;
        SwitchItems();
        Debug.Log("hotbar item: " + hotbarItem + "  inventory item: " + inventoryItem);
    }

     public void SwitchItems()
    {
        if (hotbarItem != null && inventoryItem != null)
        {
            Item tempHotbarItem = Hotbar.instance.items[hotbarIndex];
            Item tempInventoryItem = Inventory.instance.items[inventoryIndex];
            //copy inventory item and hotbar item
            Inventory.instance.items[inventoryIndex] = tempHotbarItem;
            Hotbar.instance.items[hotbarIndex] = tempInventoryItem;
            // replace inventory and hotbar item in lists
            inventoryUI.updateUI();
            hbUI.updateUI();
            inventoryItem = null;
            hotbarItem = null;
        }
    }
}

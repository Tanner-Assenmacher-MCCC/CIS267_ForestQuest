using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsContainer;
    public InventorySlot[] slots;
    public GameObject inventoryUI;
    public Hotbar hb;
    ItemSwitch itemSwitch;
    // Start is called before the first frame update
    void Start()
    {
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();
        itemSwitch = FindObjectOfType<ItemSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
            hb.ResetButtons();
        }
    }

    public void OnItemClick(int i)
    {
        Debug.Log("inventory button clicked");
        if (Inventory.instance.InBounds(i))
        {
            itemSwitch.setInventoryItem(i);
            //=============================================================================================================================
            //itemSwitch.SwitchItems();
            //=============================================================================================================================
        }
        else
        {
            itemSwitch.ResetItems();
            //=============================================================================================================================
            //itemSwitch.setInventoryItem(i);
            //=============================================================================================================================
        }
        //=============================================================================================================================
        //                                INVENTORY CODE TO CLICK TO SWITCH ITEMS IN HOTBAR
        //=============================================================================================================================
        //if (Inventory.instance.InBounds(i))
        //{
        //    if (itemSwitch.getHotbarIndex() != -1)
        //    {//click on inventory item and hotbar item selected, then switch both
        //        Debug.Log("inventory item clicked");
        //        itemSwitch.setInventoryItem(i);
        //        itemSwitch.SwitchItems();
        //        //itemSwitch.ResetItems();
        //    }
        //    else
        //    {//there is no hotbar item selected, so only set inventory item to switch
        //        itemSwitch.setInventoryItem(i);
        //    }
        //}
        //=============================================================================================================================
    }

    public void updateUI()
    {
        for (int i = 0; i < Inventory.maxItems; i++)
        {
            if (i < Inventory.instance.items.Count)
            {
                slots[i].addItem(Inventory.instance.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }
}

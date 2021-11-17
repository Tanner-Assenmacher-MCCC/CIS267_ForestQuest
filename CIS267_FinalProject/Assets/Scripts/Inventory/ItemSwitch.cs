using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSwitch : MonoBehaviour
{
    public Hotbar hotbar;
    public HotbarUI hotbarUI;
    public Inventory inventory;
    public InventoryUI inventoryUI;

    private int hotbarIndex = -1;
    private int inventoryIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Inventory"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                setHotBarItem(0);
                SwitchItems();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                setHotBarItem(1);
                SwitchItems();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                setHotBarItem(2);
                SwitchItems();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {//mouse was clicked over inventory or hotbar element
                Debug.Log("Clicked on the UI");
            }
            else
            {//mouse was not clicked on any buttons, therefore clear selections
                ResetItems();
                Debug.Log("Reset items from out mouse click");
            }
        }
    }

    public int getInventoryIndex()
    {
        return inventoryIndex;
    }

    public int getHotbarIndex()
    {
        return hotbarIndex;
    }

    public void ResetItems()
    {
        hotbarIndex = -1;
        inventoryIndex = -1;
    }

    public void ResetHotbarItem()
    {
        hotbarIndex = -1;
    }

    public void setHotBarItem(int i)
    {
        if (Hotbar.instance.InBounds(i))
        {
            hotbarIndex = i;
        }

    }

    public void setInventoryItem(int i)
    {
        if (Inventory.instance.InBounds(i))
        {
            inventoryIndex = i;
        }
    }

     public void SwitchItems()
    {
        Debug.Log(inventoryIndex);
        if (Hotbar.instance.InBounds(hotbarIndex) && Inventory.instance.InBounds(inventoryIndex))
        {
            Debug.Log("passed");
            Item tempHotBarItem = Hotbar.instance.items[hotbarIndex];
            Item tempInventoryItem = Inventory.instance.items[inventoryIndex];
            //copy inventory item and hotbar item
            Inventory.instance.items[inventoryIndex] = tempHotBarItem;
            Hotbar.instance.items[hotbarIndex] = tempInventoryItem;

            // replace inventory and hotbar item in lists
            inventoryUI.updateUI();
            hotbarUI.updateUI();
        }
    }
}

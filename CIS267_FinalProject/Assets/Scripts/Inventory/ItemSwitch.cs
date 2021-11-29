using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSwitch : MonoBehaviour
{
    private Player player;
    private Hotbar hotbar;
    private HotbarUI hotbarUI;
    private InventoryUI inventoryUI;
    public GameObject HotbarNumbers;
    public Button SelectedInventoryButton;
    private Button slotButton;
    private ColorBlock colors;
    
    private int hotbarIndex = -1;
    private int inventoryIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        hotbar = GetComponent<Hotbar>();
        hotbarUI = GetComponent<HotbarUI>();
        inventoryUI = GetComponent<InventoryUI>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Inventory"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                setHotBarItem(0);
                if (hotbar.InBounds(0))
                {
                    SwitchItems();
                }
                else if (!hotbar.InBounds(0) && !hotbar.IsFull())
                {
                    MoveItem();
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                setHotBarItem(1);
                if (hotbar.InBounds(1))
                {
                    SwitchItems();
                }
                else if (!hotbar.InBounds(1) && !hotbar.IsFull())
                {
                    MoveItem();
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                setHotBarItem(2);
                if (hotbar.InBounds(2))
                {
                    SwitchItems();
                }
                else if (!hotbar.InBounds(2) && !hotbar.IsFull())
                {
                    MoveItem();
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {//mouse was clicked over inventory or hotbar element
                SetButtonToSelectedColor();
            }
            else
            {//mouse was not clicked on any buttons, therefore clear selections
                ResetItems();
                HotbarNumbers.SetActive(false);
                inventoryUI.ResetButtonColor();
            }
        }
    }

    public void setHotbarNumbers(bool visible)
    {
        HotbarNumbers.SetActive(visible);
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
            inventoryUI.ResetButtonColor();
            SetButtonToSelectedColor();
        }
    }
    public void SetButtonToSelectedColor()
    {
        if (Inventory.instance.InBounds(inventoryIndex))
        {
            inventoryUI.ResetButtonColor();
            InventorySlot[] slots = inventoryUI.getSlots();
            InventorySlot slot = slots[inventoryIndex];
            slotButton = slot.GetButton();
            colors.normalColor = new Color32(0, 255, 83, 40);
            colors.highlightedColor = new Color32(0, 255, 83, 40);
            colors.pressedColor = new Color32(0, 0, 0, 40);
            colors.selectedColor = new Color32(0, 255, 83, 40);
            colors.disabledColor = new Color32(0, 255, 83, 40);
            colors.colorMultiplier = 1;
            colors.fadeDuration = .1f;
            slotButton.colors = colors;
        }
    }

    public void SwitchItems()
    {
        if (Hotbar.instance.InBounds(hotbarIndex) && Inventory.instance.InBounds(inventoryIndex))
        {
            Item tempHotBarItem = Hotbar.items[hotbarIndex];
            Item tempInventoryItem = Inventory.items[inventoryIndex];
            //copy inventory item and hotbar item
            Inventory.items[inventoryIndex] = tempHotBarItem;
            Hotbar.items[hotbarIndex] = tempInventoryItem;

            // replace inventory and hotbar item in lists
            inventoryUI.updateUI();
            hotbarUI.updateUI();

            //change item in holster if you swapped that item
            if (hotbarIndex == player.itemInHolster)
            {
                player.UseItem(Hotbar.items[hotbar.iw]);
            }
        }
    }

    public void MoveItem()
    {
        
        Hotbar.items.Add(Inventory.items[inventoryIndex]);
        Inventory.instance.RemoveIndex(inventoryIndex);

        // replace inventory and hotbar item in lists
        inventoryUI.updateUI();
        hotbarUI.updateUI();

        //change item in holster if you swapped that item
        if (hotbarIndex == player.itemInHolster)
        {
            player.UseItem(Hotbar.items[hotbar.iw]);
        }
    }
    
}

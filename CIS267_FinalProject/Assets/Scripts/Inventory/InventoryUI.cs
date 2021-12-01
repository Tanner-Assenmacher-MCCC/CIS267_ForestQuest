using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static bool isActive = false;
    public Transform slotsContainer;
    public InventorySlot[] slots;
    public Button[] inventoryButtons;
    public GameObject inventoryUI;
    private  Hotbar hotbar;
    private ItemSwitch itemSwitch;
    private WeaponHolster weaponHolster;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        hotbar = GetComponent<Hotbar>();
        player = FindObjectOfType<Player>();
        weaponHolster = FindObjectOfType<WeaponHolster>();
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();
        inventoryButtons = slotsContainer.GetComponentsInChildren<Button>();
        itemSwitch = FindObjectOfType<ItemSwitch>();

        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
            isActive = inventoryUI.activeInHierarchy;
            hotbar.ResetButtons(!inventoryUI.activeInHierarchy);
            hotbar.HighlightButton(player.itemInHolster);
            itemSwitch.ResetItems();
            ResetButtonColor();
            if (!inventoryUI.activeInHierarchy && hotbar.InBounds(hotbar.iw) && weaponHolster.hasWeapon)
            {
                //if (weaponHolster.SelectedItemIcon) weaponHolster.SelectedItemIcon.enabled = true;
                hotbar.HighlightButton(player.itemInHolster);
            }
            else
            {
                //if (weaponHolster.SelectedItemIcon) weaponHolster.SelectedItemIcon.enabled = false;
                hotbar.ResetButtons(false);
            }
        }
    }

    public InventorySlot[] getSlots()
    {
        return slots;
    }

    public void ResetButtonColor()
    {
        foreach (Button button in inventoryButtons)
        {
            ColorBlock colors = new ColorBlock();
            colors.normalColor = new Color32(255, 255, 255, 0);
            colors.highlightedColor = new Color32(245, 245, 245, 40);
            colors.pressedColor = new Color32(0, 0, 0, 40);
            colors.selectedColor = new Color32(0, 255, 83, 40);
            colors.disabledColor = new Color32(200, 200, 200, 128);
            colors.colorMultiplier = 1;
            colors.fadeDuration = .1f;
            button.colors = colors;
        }
    }

    public void OnItemClick(int i)
    {
        if (Inventory.instance.InBounds(i))
        {
            itemSwitch.setInventoryItem(i);
            itemSwitch.setHotbarNumbers(true);
            //=============================================================================================================================
            //itemSwitch.SwitchItems();
            //=============================================================================================================================
        }
        else
        {
            itemSwitch.ResetItems();
            ResetButtonColor();
            itemSwitch.SetButtonToSelectedColor();
            itemSwitch.setHotbarNumbers(false);
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
            if (i < Inventory.items.Count)
            {
                slots[i].addItem(Inventory.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }
}

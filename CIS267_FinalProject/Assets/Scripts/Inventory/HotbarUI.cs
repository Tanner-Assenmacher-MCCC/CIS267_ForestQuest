using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    public Transform slotsContainer;
    public InventorySlot[] slots;
    public ItemSwitch itemSwitch;
    public Player p;
    public Hotbar hb;
    public WeaponHolster wh;
    // Start is called before the first frame update
    void Start()
    {
        p = FindObjectOfType<Player>();
        hb = FindObjectOfType<Hotbar>();
        wh = FindObjectOfType<WeaponHolster>();
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnItemClick(int i)
    {
        Player player = FindObjectOfType<Player>();
        hb.iw = i;
        if (hb.InBounds(hb.iw))
        {
            player.itemInHolster = i;
            player.UseItem(this.hb.items[hb.iw]);
            hb.ResetButtons(true);
            hb.HighlightClickButton(i);
            if (i == 0)
            {
                hb.weaponHolster.SelectedItemIcon.transform.position = new Vector3(-1.05f, -3.75f, 0f);
            }
            if (i == 1)
            {
                hb.weaponHolster.SelectedItemIcon.transform.position = new Vector3(0f, -3.75f, 0f);
            }
            if (i == 2)
            {
                hb.weaponHolster.SelectedItemIcon.transform.position = new Vector3(1.075f, -3.75f, 0f);
            }
        }
        //keep inventory button selected
        //itemSwitch.SetButtonToSelectedColor();

        //=============================================================================================================================
        //                                INVENTORY CODE TO CLICK TO SWITCH ITEMS IN HOTBAR
        //=============================================================================================================================
        //if (Hotbar.instance.InBounds(i))
        //{
        //    if(itemSwitch.getInventoryIndex() != -1)
        //    {//click on hotbar item and inventory item selected, then switch both
        //        Debug.Log("hotbar item clicked");
        //        itemSwitch.setHotBarItem(i);
        //        itemSwitch.SwitchItems();
        //        //itemSwitch.ResetItems();
        //    }
        //    else
        //    {//there is no inventory item selected, so only set hotbar item to switch
        //        itemSwitch.setHotBarItem(i);
        //    }
        //}
        //=============================================================================================================================
    }

    public InventorySlot[] getSlots()
    {
        return slots;
    }

    public void updateUI()
    {
        for (int i = 0; i < Hotbar.maxItems; i++)
        {
            if (i < Hotbar.instance.items.Count)
            {
                slots[i].addItem(Hotbar.instance.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }
}

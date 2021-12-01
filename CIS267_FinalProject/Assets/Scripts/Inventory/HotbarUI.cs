using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    [SerializeField] private Transform slotsContainer;
    public InventorySlot[] slots;
    private ItemSwitch itemSwitch;
    private Hotbar hotbar;
    // Start is called before the first frame update
    void Start()
    {
        itemSwitch = GetComponent<ItemSwitch>();
        hotbar = GetComponent<Hotbar>();
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();

        updateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnItemClick(int i)
    {
        Player player = FindObjectOfType<Player>();
        hotbar.iw = i;
        if (hotbar.InBounds(hotbar.iw))
        {
            player.itemInHolster = i;
            player.UseItem(Hotbar.items[hotbar.iw]);
            hotbar.ResetButtons(true);
            hotbar.HighlightClickButton(i);
            if (i == 0)
            {
                //hotbar.weaponHolster.SelectedItemIcon.transform.position = new Vector3(-1.05f, -3.75f, 0f);
            }
            if (i == 1)
            {
                //hotbar.weaponHolster.SelectedItemIcon.transform.position = new Vector3(0f, -3.75f, 0f);
            }
            if (i == 2)
            {
                //hotbar.weaponHolster.SelectedItemIcon.transform.position = new Vector3(1.075f, -3.75f, 0f);
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

    public void updateUI()
    {
        for (int i = 0; i < Hotbar.maxItems; i++)
        {
            if (i < Hotbar.items.Count)
            {
                slots[i].addItem(Hotbar.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }
}

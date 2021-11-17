using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotbarUI : MonoBehaviour
{
    public Transform slotsContainer;
    public InventorySlot[] slots;
    public ItemSwitch itemSwitch;
    // Start is called before the first frame update
    void Start()
    {
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnItemClick(int i)
    {
        if (Hotbar.instance.InBounds(i))
        {
            if(itemSwitch.getInventoryIndex() != -1)
            {//click on hotbar item and inventory item selected, then switch both
                Debug.Log("hotbar item clicked");
                itemSwitch.setHotBarItem(i);
                itemSwitch.SwitchItems();
                //itemSwitch.ResetItems();
            }
            else
            {//there is no inventory item selected, so only set hotbar item to switch
                itemSwitch.setHotBarItem(i);
            }
            
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsContainer;
    public InventorySlot[] slots;
    public GameObject inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        //Inventory.instance.itemChanged += updateUI;
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();
        Debug.Log(slots);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
        }
    }

    public void updateUI()
    {
        //Debug.Log("Update UI");
        //for (int i = 0; i < slots.Length; i++)
        //{
        //    if (i < inventory.items.Count)
        //    {
        //        slots[i].addItem(inventory.items[i]);
        //    }
        //    else
        //    {
        //        slots[i].clearSlot();
        //    }
        //}

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

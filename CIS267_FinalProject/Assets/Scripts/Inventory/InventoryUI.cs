using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    public Transform slotsContainer;
    InventorySlot[] slots;
    public GameObject inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.itemChanged += updateUI;
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    public void updateUI()
    {
        Debug.Log("Update UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].addItem(inventory.items[i]);
            }
            else
            {
                slots[i].clearSlot();
            }
        }
    }
}

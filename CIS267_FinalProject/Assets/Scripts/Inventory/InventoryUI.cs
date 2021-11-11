using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsContainer;
    public InventorySlot[] slots;
    public GameObject inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeInHierarchy);
        }
    }

    public void OnItemClick()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
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

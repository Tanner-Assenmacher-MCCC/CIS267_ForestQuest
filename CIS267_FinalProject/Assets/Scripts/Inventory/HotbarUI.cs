using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HotbarUI : MonoBehaviour
{
    public Transform slotsContainer;
    public InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
        slots = slotsContainer.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnItemClick()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
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

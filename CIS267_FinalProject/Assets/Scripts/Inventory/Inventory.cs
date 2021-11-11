using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public static int maxItems = 16;
    public List<Item> items = new List<Item>(maxItems);
    [SerializeField] private InventoryUI inventoryUI;

    public delegate void OnChange();
    public OnChange onChangeCallback;
    // If we need a function called after an item is added or removed you can add it like this:
    // Inventory.instance.onChangeCallback += function;
    
    private void Awake()
    {
        instance = this;
    }

    public bool IsFull()
    {
        return items.Count >= items.Capacity;
    }

    public bool Add(Item item)
    {
        if (IsFull()) return false;
        items.Add(item);
        inventoryUI.updateUI();
        if (onChangeCallback != null) onChangeCallback();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        inventoryUI.updateUI();
        if (onChangeCallback != null) onChangeCallback();
    }

    public void RemoveIndex(int i)
    {
        items.RemoveAt(i);
        inventoryUI.updateUI();
        if (onChangeCallback != null) onChangeCallback();
    }

}

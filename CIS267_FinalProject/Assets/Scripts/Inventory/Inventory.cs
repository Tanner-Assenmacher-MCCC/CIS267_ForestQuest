using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public static int maxItems = 16;
    public List<Item> items = new List<Item>(maxItems);
    InventoryUI inventoryUI;
    //public delegate void onItemChange();
    //public onItemChange itemChanged;
    //itemChanged is callback
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
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
        //if (itemChanged != null) 
        //itemChanged.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        inventoryUI.updateUI();
        //if (itemChanged != null)
        //itemChanged.Invoke();
    }

    public void RemoveIndex(int i)
    {
        items.RemoveAt(i);
        inventoryUI.updateUI();
        //if (itemChanged != null)
        //itemChanged.Invoke();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public static int maxItems = 24;
    public List<Item> items = new List<Item>(maxItems);
    public delegate void onItemChange();
    public onItemChange itemChanged;
    //itemChanged is callback
    
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
        if (itemChanged != null) 
        itemChanged.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (itemChanged != null)
        itemChanged.Invoke();
    }

    public void RemoveIndex(int i)
    {
        items.RemoveAt(i);
        if (itemChanged != null)
        itemChanged.Invoke();
    }

}

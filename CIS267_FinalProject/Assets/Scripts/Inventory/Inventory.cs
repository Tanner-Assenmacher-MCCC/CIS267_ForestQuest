using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public static int maxItems = 24;
    public List<Item> items = new List<Item>(maxItems);
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
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void RemoveIndex(int i)
    {
        items.RemoveAt(i);
    }

}

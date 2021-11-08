using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public static int maxItems = 24;
    public List<GameObject> items = new List<GameObject>(maxItems);
    private void Awake()
    {
        instance = this;
    }

    public bool IsFull()
    {
        return items.Count >= items.Capacity;
    }

    public bool AddItem(GameObject gameObject)
    {
        if (IsFull()) return false;
        items.Add(gameObject);
        return true;
    }

    public void RemoveItem(GameObject gameObject)
    {
        items.Remove(gameObject);
    }

    public void RemoveItem(int i)
    {
        items.RemoveAt(i);
    }

}

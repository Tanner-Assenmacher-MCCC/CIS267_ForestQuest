using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance = null;
    public static int maxItems = 16;
    public static List<Item> items = new List<Item>(maxItems);
    private InventoryUI inventoryUI;

    public delegate void OnChange();
    public OnChange onChangeCallback;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }

    public bool IsFull()
    {
        return items.Count >= items.Capacity;
    }

    public bool InBounds(int i)
    {
        return i >= 0 && i < items.Count;
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

    public void DropItem(int i)
    {
        float drag = 4.5f;
        float force = 100f;
        float itemDropOffset = 1.5f;
        Player player = FindObjectOfType<Player>();
        float horizontal = player.animator.GetFloat("lastMoveHorizontal");
        float vertical = player.animator.GetFloat("lastMoveVertical");

        Vector3 offset = new Vector3(horizontal, vertical, 0) * itemDropOffset;
        offset.z = player.transform.position.z;
        Vector2 push = new Vector2(horizontal, vertical) * force;

        GameObject instance = Instantiate(items[i].prefab, player.transform.position + offset, transform.rotation);
        instance.GetComponent<Rigidbody2D>().AddForce(push);

        instance.GetComponent<Rigidbody2D>().drag = drag;
        this.RemoveIndex(i);
    }

    }

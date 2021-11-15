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

        GameObject instance = Instantiate(this.items[i].prefab, player.transform.position + offset, transform.rotation);
        instance.GetComponent<Rigidbody2D>().AddForce(push);

        instance.GetComponent<Rigidbody2D>().drag = drag;
        this.RemoveIndex(i);
    }

    }

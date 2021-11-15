using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public static Hotbar instance;
    public static int maxItems = 3;
    public List<Item> items = new List<Item>(maxItems);
    [SerializeField] private HotbarUI hotbarUI;

    public delegate void OnChange();
    public OnChange onChangeCallback;
    // If we need a function called after an item is added or removed you can add it like this:
    // Inventory.instance.onChangeCallback += function;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Player player = FindObjectOfType<Player>();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("asdasd");
            int i = 0;
            if (InBounds(i))
            {
                player.UseItem(this.items[i] as ScriptableWeapon);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            int i = 1;
            if (InBounds(i)) this.DropItem(i);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            int i = 2;
            if (InBounds(i)) this.DropItem(i);
        }
    }

    public bool InBounds(int i)
    {
        return i >= 0 && i < items.Count;
    }

    public bool IsFull()
    {
        return items.Count >= items.Capacity;
    }

    public bool Add(Item item)
    {
        if (IsFull()) return false;
        items.Add(item);
        hotbarUI.updateUI();
        if (onChangeCallback != null) onChangeCallback();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        hotbarUI.updateUI();
        if (onChangeCallback != null) onChangeCallback();
    }

    public void RemoveIndex(int i)
    {
        items.RemoveAt(i);
        hotbarUI.updateUI();
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

        //if (horizontal == 0f && vertical == 1f) // up
        //{
        //    instance = Instantiate(this.items[i].prefab, player.transform.position + new Vector3(0f, itemDropOffset, 0f), transform.rotation);
        //    instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, force));
        //}
        //else if (horizontal == 1f && vertical == 0f) // right
        //{
        //    instance = Instantiate(this.items[i].prefab, player.transform.position + new Vector3(itemDropOffset, 0f, 0f), transform.rotation);
        //    instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, 0f));
        //}
        //else if (horizontal == 0f && vertical == -1f) // down
        //{
        //    instance = Instantiate(this.items[i].prefab, player.transform.position + new Vector3(0f, -itemDropOffset, 0f), transform.rotation);
        //    instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -force));
        //}
        //else // left
        //{
        //    instance = Instantiate(this.items[i].prefab, player.transform.position + new Vector3(-itemDropOffset, 0f, 0f), transform.rotation);
        //    instance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-force, 0f));
        //}
        instance.GetComponent<Rigidbody2D>().drag = drag;
        this.RemoveIndex(i);
    }
}

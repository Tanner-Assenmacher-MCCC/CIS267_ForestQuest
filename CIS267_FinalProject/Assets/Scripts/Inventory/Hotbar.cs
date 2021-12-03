using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public static Hotbar instance = null;
    public static int maxItems = 3;
    public static List<Item> items = new List<Item>(maxItems);
    [SerializeField] private List<Button> slotButtons;
    private HotbarUI hotbarUI;
    private ItemSwitch itemSwitch;

    public delegate void OnChange();
    public OnChange onChangeCallback;
    
    public int iw;
    [System.NonSerialized] public WeaponHolster weaponHolster;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        hotbarUI = GetComponent<HotbarUI>();
        weaponHolster = FindObjectOfType<WeaponHolster>();
        itemSwitch = GetComponent<ItemSwitch>();
    }

    private void Update()
    {
        if (GameObject.Find("Inventory")) return;
        WeaponHolster weaponHolster = FindObjectOfType<WeaponHolster>();
        Player player = FindObjectOfType<Player>();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            
            if (InBounds(0))
            {
                iw = 0;
                player.itemInHolster = 0;
                player.UseItem(items[iw]);
                //weaponHolster.SelectedItemIcon.transform.position = new Vector3(-1.05f, -3.75f, 0f);
                ResetButtons(true);
                HighlightButton(iw);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            if (InBounds(1))
            {
                iw = 1;
                player.itemInHolster = 1;
                player.UseItem(items[iw]);
                //weaponHolster.SelectedItemIcon.transform.position = new Vector3(0f, -3.75f, 0f);
                ResetButtons(true);
                HighlightButton(iw);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
            if (InBounds(2))
            {
                iw = 2;
                player.itemInHolster = 2;
                player.UseItem(items[iw]);
                //weaponHolster.SelectedItemIcon.transform.position = new Vector3(1.075f, -3.75f, 0f);
                ResetButtons(true);
                HighlightButton(iw);
            }
        }
    }

    public void ResetButtons(bool setActive)
    {
        foreach (Button button in slotButtons)
        {
            ColorBlock colors = button.colors;
            colors.normalColor = new Color32(255, 255, 255, 0);
            colors.highlightedColor = new Color32(255, 255, 255, 0);
            colors.selectedColor = new Color32(255, 255, 255, 0);
            button.colors = colors;
            itemSwitch.setHotbarNumbers(false);
            WeaponHolster weaponHolster = FindObjectOfType<WeaponHolster>();
            //if (weaponHolster.SelectedItemIcon) weaponHolster.SelectedItemIcon.enabled = setActive;

        }
    }

    public void HighlightButton(int i)
    {
        ColorBlock colors = slotButtons[i].colors;
        colors.normalColor = new Color32(255, 255, 255, 40);
        colors.highlightedColor = new Color32(255, 255, 255, 40);
        slotButtons[i].colors = colors;
        WeaponHolster weaponHolster = FindObjectOfType<WeaponHolster>();
        //if (weaponHolster.SelectedItemIcon) weaponHolster.SelectedItemIcon.enabled = true;
    }
    
    public void HighlightClickButton(int i)
    {
        ColorBlock colors = slotButtons[i].colors;
        colors.normalColor = new Color32(255, 255, 255, 40);
        colors.highlightedColor = new Color32(255, 255, 255, 40);
        colors.selectedColor = new Color32(255, 255, 255, 40);
        slotButtons[i].colors = colors;
        WeaponHolster weaponHolster = FindObjectOfType<WeaponHolster>();
        //if (weaponHolster.SelectedItemIcon) weaponHolster.SelectedItemIcon.enabled = true;
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
        Item item = items[i];
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
        if ((weaponHolster.scriptableWeapon != null ? weaponHolster.scriptableWeapon.name == item.name : false))
        {//item.GetType() != typeof(ScriptableWeapon) || 
            FindObjectOfType<WeaponHolster>().ResetWeapon();
        }
        this.RemoveIndex(i);
        itemSwitch.ResetHotbarItem();
        ResetButtons(false);
        HighlightButton(iw);

    }
}

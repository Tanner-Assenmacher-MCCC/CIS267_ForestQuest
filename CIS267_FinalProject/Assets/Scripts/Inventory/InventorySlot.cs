using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject slotObject;
    public Button slotButton;
    public Item item = null;
    private bool isHovered = false;

    void Start()
    {
        slotButton = this.GetComponentInChildren<Button>();
    }
    private void Update()
    {
        if (isHovered && Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (item != null)
            {
                int i = int.Parse(this.name.Split('_')[1]) - 1;
                if (this.transform.parent.gameObject.name.Contains("Hotbar"))
                {
                    FindObjectOfType<Hotbar>().DropItem(i);
                }
                else
                {
                    FindObjectOfType<Inventory>().DropItem(i);
                }
            }
        }
    }

    public Button GetButton()
    {
        return slotButton;
    }

    public void addItem(Item newItem)
    {
        
        item = newItem;
        slotObject.GetComponent<SpriteRenderer>().sprite = item.sprite;
        slotObject.gameObject.SetActive(true);
        slotObject.transform.rotation = newItem.GetType() == typeof(ScriptableWeapon) ? Quaternion.Euler(0, 0, 40) : Quaternion.Euler(0, 0, 0);
    }

    public void clearSlot()
    {
       
        item = null;
        slotObject.GetComponent<SpriteRenderer>().sprite = null;
        slotObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}

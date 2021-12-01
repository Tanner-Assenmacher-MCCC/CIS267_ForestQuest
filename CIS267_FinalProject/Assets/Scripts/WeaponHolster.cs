using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolster : MonoBehaviour
{
    public ScriptableWeapon scriptableWeapon = null;
    public bool hasWeapon = false;
    //public Image SelectedItemIcon;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(SelectedItemIcon);
        if (hasWeapon)
        {
            GetComponent<SpriteRenderer>().sprite = scriptableWeapon.sprite;
            this.name = scriptableWeapon.name;
            //SelectedItemIcon.enabled = true;

            Debug.Log("Weapon Equipped: " + scriptableWeapon.name);
            Debug.Log("Damage: " + scriptableWeapon.damage);
        }
        else
        {
            //if (SelectedItemIcon) SelectedItemIcon.enabled = false;
            Debug.Log("No Scriptable Weapon");
        }
    }

    public void ResetWeapon()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        this.scriptableWeapon = null;
        this.hasWeapon = false;
        //SelectedItemIcon.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolster : MonoBehaviour
{
    public ScriptableWeapon scriptableWeapon = null;
    public bool hasWeapon = false;
    public GameObject SelectedItemIcon;

    // Start is called before the first frame update
    void Start()
    {
        if (hasWeapon)
        {
            GetComponent<SpriteRenderer>().sprite = scriptableWeapon.sprite;
            this.name = scriptableWeapon.name;
            SelectedItemIcon.SetActive(true);

            Debug.Log("Weapon Equipped: " + scriptableWeapon.name);
            Debug.Log("Damage: " + scriptableWeapon.damage);
        }
        else
        {
            SelectedItemIcon.SetActive(false);
            Debug.Log("No Scriptable Weapon");
        }
    }

    public void ResetWeapon()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        this.scriptableWeapon = null;
        this.hasWeapon = false;
        SelectedItemIcon.SetActive(false);
    }
}

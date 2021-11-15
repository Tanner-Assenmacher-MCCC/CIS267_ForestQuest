using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolster : MonoBehaviour
{
    public ScriptableWeapon scriptableWeapon = null;
    public bool hasWeapon = true;

    // Start is called before the first frame update
    void Start()
    {
        if (hasWeapon)
        {
            GetComponent<SpriteRenderer>().sprite = scriptableWeapon.sprite;
            this.name = scriptableWeapon.name;

            Debug.Log("Weapon Equipped: " + scriptableWeapon.name);
            Debug.Log("Damage: " + scriptableWeapon.damage);
        }
        else
        {
            Debug.Log("No Scriptable Weapon");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

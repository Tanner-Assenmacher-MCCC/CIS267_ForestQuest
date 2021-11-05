using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ScriptableWeapon scriptableWeapon;
    [SerializeField] SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend.sprite = scriptableWeapon.sprite;
        name = scriptableWeapon.name;

        Debug.Log("Weapon Equipped: " + scriptableWeapon.name);
        Debug.Log("Damage: " + scriptableWeapon.damage);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

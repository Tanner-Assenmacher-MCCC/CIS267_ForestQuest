using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Scripted objects/New weapon")]
public class ScriptableWeapon : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int damage;
}

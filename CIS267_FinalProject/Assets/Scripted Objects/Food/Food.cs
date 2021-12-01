using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Items/New Food Item")]
public class Food : Item
{
    public int healthValue = 0;
    public int xpValue = 0;
}

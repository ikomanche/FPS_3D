using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;
    public int id;
    public string description;
    public string type;
    public int Damage;
    public int AmmoCap;
    public float Range;
    public Sprite icon;
    public bool pickedUp;
    public int cellIndex;
    public bool hasOwn = false;
}

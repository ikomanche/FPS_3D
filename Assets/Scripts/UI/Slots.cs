using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public bool empty = true;
    public Sprite icon;
    public int id;
    public string description;
    public string type;
    public GameObject item;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInfoPanel : MonoBehaviour
{
    public GameObject txt1;
    public GameObject txt2;
    public GameObject txt3;
    public GameObject txt4;
    public GameObject CellHolder;
    public GameObject NameTxt;
    private GameObject gameObj;
    private int Index;    
    private void Start()
    {
        
    }

    private void Update()
    {
        Index = GlobalInvIndex.Index;       
        gameObj = CellHolder.transform.GetChild(Index).gameObject;
        txt1.GetComponent<Text>().text = "Damage : " + GlobalInvIndex.Damage;
        txt2.GetComponent<Text>().text = "Ammo Capacity : " + GlobalInvIndex.AmmoCapacity;
        txt3.GetComponent<Text>().text = "Type : " + GlobalInvIndex.Description;
        txt4.GetComponent<Text>().text = "Range :" + GlobalInvIndex.Range;
        NameTxt.GetComponent<Text>().text = GlobalInvIndex.Name;
    }

}

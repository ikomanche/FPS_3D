using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagPanelButtons : MonoBehaviour
{
    public GameObject realItem;
    public GameObject player;
    public GameObject Object;
    //void AddItem(GameObject itemObject,int itemID, string itemType, string itemDescription, Sprite itemIcon, int itemIndex)
    private GameObject itemObject;
    private int itemID, itemIndex;
    private string itemType, itemDescription;
    private Sprite itemIcon;    
    void Start()
    {        
        itemObject = GetComponent<Slots>().item;
        itemID = GetComponent<Slots>().id;
        itemType = GetComponent<Slots>().type;
        itemDescription = GetComponent<Slots>().description;
        itemIcon = GetComponent<Slots>().icon;
        itemIndex = 0;
        //Inventory inv = player.GetComponent<Inventory>();
    }

    public void GetItem()
    {
        //SendMessage("AddItem", itemObject, itemID, itemType, itemDescription, itemIcon, itemIndex, SendMessageOptions.DontRequireReceiver);
        /*Inventory inv = player.GetComponent<Inventory>();
        inv.AddItem(player.GetComponent<Inventory>(),itemObject, itemID, itemType, itemDescription, itemIcon, itemIndex);*/
        player.transform.SendMessage("BagPanelClicked", itemObject, SendMessageOptions.DontRequireReceiver);
        GetComponent<Image>().color = new Color(255, 255, 255, 0);
        DeleteItem();
    }

    public void DeleteItem() //clears the BagOpenPanel.Slots()
    {
        itemObject = GetComponent<Slots>().item = null;
        itemID = GetComponent<Slots>().id = 0;
        itemType = GetComponent<Slots>().type = null;
        itemDescription = GetComponent<Slots>().description = null;
        itemIcon = GetComponent<Slots>().icon = null;
        realItem.GetComponent<Item>().hasOwn = true;
    }
    
    void Update()
    {
        
    }
}

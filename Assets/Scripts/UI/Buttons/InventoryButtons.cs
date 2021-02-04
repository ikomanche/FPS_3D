using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButtons : MonoBehaviour
{
    public GameObject healFlash;
    public GameObject emptyCell;
    public GameObject _panel;
    public GameObject player;
    public GameObject theCell;
    public GameObject paneltoLoad1;
    public GameObject panelToLoad2;
    public GameObject cellIcon;
    public int cellIndex;
    private GameObject theObject;
    private bool panelActive;

    public void ShowPanel()
    {
        if(theCell.transform.GetChild(1).gameObject != null)
        {
            theObject = theCell.transform.GetChild(1).gameObject;
            theObject.GetComponent<Item>().cellIndex = theCell.GetComponent<InventoryButtons>().cellIndex;
            print(theObject.GetComponent<Item>().cellIndex);
        }
                    
        //theObject.GetComponent<Sprite>().texture
        if (theObject.tag == "Item2")
        {            
            panelToLoad2.SetActive(true);
            /*paneltoLoad1.SetActive(true);
            cellIcon.GetComponent<Image>().sprite = theObject.GetComponent<Image>().sprite;*/
        }            
        if(theObject.tag == "Item" || theObject.tag == "Collectable")
        {
            GlobalInvIndex.Index = cellIndex;
            GlobalInvIndex.Damage = theObject.GetComponent<Item>().Damage;
            GlobalInvIndex.AmmoCapacity = theObject.GetComponent<Item>().AmmoCap;
            GlobalInvIndex.Description = theObject.GetComponent<Item>().description;
            GlobalInvIndex.Range = theObject.GetComponent<Item>().Range;
            GlobalInvIndex.Name = theObject.GetComponent<Item>().Name;
            paneltoLoad1.SetActive(true);
            cellIcon.GetComponent<Image>().sprite = theCell.GetComponent<Slots>().icon; //.GetComponent<Slots>().icon;
            //cellIcon.GetComponent<Image>().sprite = theObject.GetComponent<Image>().sprite;
        }       
    }

    public void Use()
    {
        if (theCell.transform.GetChild(1).gameObject != null)
        {
            theObject = theCell.transform.GetChild(1).gameObject;
            theObject.GetComponent<Item>().cellIndex = theCell.GetComponent<InventoryButtons>().cellIndex;
            //print(theObject.GetComponent<Item>().cellIndex);
        }

        if(theObject.tag == "Collectable")
        {
            GlobalHealth.healthValue += theObject.GetComponent<Item>().Damage;
            if(GlobalHealth.healthValue > 100)
            {
                GlobalHealth.healthValue = 100;
            }
            StartCoroutine(HealEffect());
            GetComponent<Slots>().icon = null;
            GetComponent<Slots>().id = 0;
            GetComponent<Slots>().description = null;
            GetComponent<Slots>().type = null;
            GetComponent<Slots>().item = null;
            GetComponent<Slots>().empty = true;
            theCell.transform.GetChild(0).gameObject.SetActive(false);
            //player.transform.SendMessage("DeleteItem", theObject, SendMessageOptions.DontRequireReceiver);
            Destroy(theObject);
            GetComponent<Image>().sprite = emptyCell.GetComponent<Image>().sprite;
        }
        if(theObject.GetComponent<Item>().type == "Weapon")
        {
            WeaponSwitch.selectedWeapon = theObject.GetComponent<Item>().id - 1;
        }
    }

    public void FirstClick()
    {
        if (panelActive)
        {
            _panel.SetActive(false);
            panelActive = !panelActive;
        }
        else //(theCell.transform.GetChild(1).gameObject != null)
        {
            _panel.SetActive(true);
            panelActive = !panelActive;
        }        
    }

    IEnumerator HealEffect()
    {
        healFlash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        healFlash.SetActive(false);
    }
}

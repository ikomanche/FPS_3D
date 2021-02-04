using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private bool inventoryEnabled = false;
    public GameObject inventory;
    public GameObject inventoryIcon;
    private int allCells;
    private int enabledSlots;
    public GameObject[] cell;
    //private List<GameObject> cell;
    public GameObject cellHolder;
    bool isCollide = false;
    private GameObject theObject;
    private bool bagPanel;
    public static int currentCapacity;
    private bool closeButtonClicked = false;

    private void Start()
    {
        allCells = 19;
        currentCapacity = 0;
        cell = new GameObject[allCells];
        bagPanel = false;


        for(int i = 0; i < allCells; i++)
        {            
            cell[i] = cellHolder.transform.GetChild(i).gameObject;
            if (cell[i].GetComponent<Slots>().item == null)
                cell[i].GetComponent<Slots>().empty = true;
        }
    }

    /*public Inventory()
    {
        allCells = 19;
        cell = new GameObject[allCells];



        for (int i = 0; i < allCells; i++)
        {
            cell[i] = cellHolder.transform.GetChild(i).gameObject;
            if (cell[i].GetComponent<Slots>().item == null)
                cell[i].GetComponent<Slots>().empty = true;
        }
    }*/

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;
        if(inventoryEnabled)
        {
            //inventory.SetActive(true);
            PanelActive();
        }
        else
        {
            PanelDeActivate();
            //inventory.SetActive(false);
        }  
        
        if(isCollide && Input.GetKeyDown(KeyCode.E))
        {
            print("collusion and E");
            //GameObject itemPickedUp = other.gameObject;
            
            Item item = theObject.GetComponent<Item>();

            StartCoroutine(InvAnim());
            AddItem(this,theObject, item.id, item.type, item.description, item.icon, item.cellIndex);
        } //if user takes the note to inventory (or any other thing)

        if (isCollide && Input.GetKeyDown(KeyCode.R))
        {
            print("collusion and E");
            //GameObject itemPickedUp = other.gameObject;

            Item item = theObject.GetComponent<Item>();

            AddItem(this,theObject, item.id, item.type, item.description, item.icon, item.cellIndex);
        } //if user reads the note (implemented for reading only)

        /*if(bagPanel)
        {
            Item item = theObject.GetComponent<Item>();

            AddItem(this, theObject, item.id, item.type, item.description, item.icon, item.cellIndex);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {        
        print("triggered");
        if(other.tag == "Item" || other.tag == "Item2")
        {
            print("tag is item");
            GameObject itemPickedUp = other.gameObject;
            theObject = itemPickedUp;
            isCollide = true;
            //Item item = itemPickedUp.GetComponent<Item>();

            //AddItem(itemPickedUp, item.id, item.type, item.description, item.icon);                       
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        isCollide = false;
    }*/


    public void AddItem(Inventory obj,GameObject itemObject,int itemID, string itemType, string itemDescription, Sprite itemIcon, int itemIndex)
    {
        print("AddItem()");
        //allCells = 19;
        bool found = false;
        print(allCells);
        for (int i = 0; i < obj.allCells; i++)
        {
            if (!found/* && isCollide*/)
            {
                if (obj.cell[i].GetComponent<Slots>().empty)
                {
                    print("found");
                    itemObject.GetComponent<Item>().pickedUp = true;
                    itemObject.GetComponent<Item>().cellIndex = i;

                    obj.cell[i].GetComponent<Slots>().item = itemObject;
                    obj.cell[i].GetComponent<Slots>().icon = itemIcon;
                    obj.cell[i].GetComponent<Slots>().type = itemType;
                    obj.cell[i].GetComponent<Slots>().id = itemID;
                    obj.cell[i].GetComponent<Slots>().description = itemDescription;
                   

                    itemObject.transform.parent = obj.cell[i].transform;
                    itemObject.SetActive(false);
                    //Destroy(itemObject.GetComponent<Collider>().gameObject);
                    obj.cell[i].GetComponent<Slots>().UpdateSlot();
                    obj.cell[i].GetComponent<Slots>().empty = false;
                    found = true;
                    isCollide = false;
                    bagPanel = false;
                    currentCapacity++;
                    itemObject.GetComponent<Item>().hasOwn = true;
                }
            }
            //print("next cell");
        }               
    }    

    public void DeleteItem(GameObject itemObject)
    {        
        int idx = itemObject.GetComponent<Item>().cellIndex;
        //Destroy(cell[idx].transform.GetChild(1));
        //cell[idx] = null;
        cell[idx].GetComponent<Slots>().icon = itemObject.GetComponent<Item>().icon;
    }

    public void UpdateInventory(int from)
    {

    }

    IEnumerator InvAnim()
    {
        inventoryIcon.GetComponent<Animator>().Play("AddedToInventory");
        yield return new WaitForSeconds(0.667f);
        inventoryIcon.GetComponent<Animator>().Play("New State");
    }

    public void BagPanelClicked(GameObject theObj)
    {
        print("Message");
        //print(allCells);
        //this.bagPanel = true;
        this.theObject = theObj;

        Item item = theObject.GetComponent<Item>();

        AddItem(this, theObject, item.id, item.type, item.description, item.icon, item.cellIndex);
    }

    public void PanelActive()
    {
        if (!closeButtonClicked)
            inventory.SetActive(true);
        else
        {
            inventory.SetActive(false);
            closeButtonClicked = false;
            inventoryEnabled = !inventoryEnabled;
        }
            
    }

    public void PanelDeActivate()
    {
        inventory.SetActive(false);
    }

    public void closeButton()
    {
        closeButtonClicked = true;
    }
}

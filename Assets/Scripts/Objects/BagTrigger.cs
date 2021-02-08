using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagTrigger : MonoBehaviour
{
    public GameObject bagContainerPanel;
    public GameObject txtOpen;
    private bool isCollide = false;
    void Start()
    {
        GetComponent<Animator>().Play("bagIdle");
    }

    
    void Update()
    {
        if(isCollide)
        {
            txtOpen.SetActive(true);
        }

        if(isCollide && Input.GetKeyDown(KeyCode.E))
        {
            bagContainerPanel.SetActive(true);
            txtOpen.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isCollide = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isCollide = false;
        txtOpen.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFirst : MonoBehaviour
{
    public GameObject txtNeedKey;
    public GameObject realKey;
    public GameObject theDoor;
    public AudioSource doorFX;
    public GameObject txtOpenDoor;
    public bool isCollide = false;
    [SerializeField]
    private bool isEnemy = false, isOpen = false;
    
    private void Update()
    {   
        if(isCollide && Input.GetKeyDown(KeyCode.E))
        {
            if (!realKey.activeSelf)
            {
                txtNeedKey.SetActive(true);
                StartCoroutine(txtFadeTime());
            }
            else
            {
                doorFX.Play();
                isOpen = true;
                theDoor.GetComponent<Animator>().Play("DoorOpen");
                //this.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(CloseDoor());
            }            
        }
        if(isEnemy && isCollide && !isOpen)
        {
            doorFX.Play();
            theDoor.GetComponent<Animator>().Play("DoorOpen");            
            StartCoroutine(CloseDoor());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            txtOpenDoor.SetActive(true);
        }
        if(other.transform.tag == "Enemy")
        {
            isEnemy = true;
        }
        isCollide = true;        
    }
    private void OnTriggerExit(Collider other)
    {
        isCollide = false;
        isEnemy = false;
        txtOpenDoor.SetActive(false);
    }

    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(5);
        doorFX.Play();
        theDoor.GetComponent<Animator>().Play("DoorClose");
        //this.GetComponent<BoxCollider>().enabled = true;
        isCollide = false;
        isOpen = false;
    }

    IEnumerator txtFadeTime()
    {
        yield return new WaitForSeconds(5);
        txtNeedKey.SetActive(false);
    }

}

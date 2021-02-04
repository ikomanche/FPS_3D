using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePickUp : MonoBehaviour
{
    public AudioSource paperSound;
    public GameObject letter;
    public GameObject txtRead;
    public GameObject letterPanel;
    public bool isCollide = false;
    private void OnTriggerEnter(Collider other)
    {
        isCollide = true;
        txtRead.SetActive(true);
    }       

    private void OnTriggerExit(Collider other)
    {
        print("exitTriggerFirst");        
        txtRead.SetActive(false);
        isCollide = false;
        //letterPanel.SetActive(false);
    }
        

    private void Update()
    {
        if(isCollide && Input.GetKeyDown(KeyCode.R))
        {   
            letter.SetActive(false);
            paperSound.Play();
            letterPanel.SetActive(true);
            //isCollide = false;
        }
        if (isCollide && Input.GetKeyDown(KeyCode.E))
        {
            letter.SetActive(false);
            paperSound.Play();
            //print("Here");
            //letterPanel.SetActive(false);
            txtRead.SetActive(false);
            //isCollide = false;
        }
    }
    
}

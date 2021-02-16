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
        if(other.transform.tag == "Player")
        {
            isCollide = true;
            txtRead.SetActive(true);
        }        
    }       

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            //print("exitTriggerFirst");
            txtRead.SetActive(false);
            isCollide = false;
            //letterPanel.SetActive(false);
        }

    }
        

    private void Update()
    {
        if(isCollide && Input.GetKeyDown(KeyCode.R))
        {
            if (gameObject.transform.name == "letterTemplate2")
            {
                paperSound.Play();
                txtRead.SetActive(false);
                gameObject.SetActive(false);
                letterPanel.SetActive(true);
            }
            else
            {
                letter.SetActive(false);
                paperSound.Play();
                letterPanel.SetActive(true);
                txtRead.SetActive(false);
                //isCollide = false;
            }

        }
        if (isCollide && Input.GetKeyDown(KeyCode.E))
        {
            txtRead.SetActive(false);
            if (gameObject.transform.name == "letterTemplate2")
            {                
                paperSound.Play();
                txtRead.SetActive(false);
                gameObject.SetActive(false);
            }
            else
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
    
}

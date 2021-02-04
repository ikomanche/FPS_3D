using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPickUp : MonoBehaviour
{
    public Sprite keySprite;
    public GameObject keyPanel1;
    public AudioSource keySound;
    public GameObject txtTakeKey;
    public GameObject realKey;
    public GameObject fakeKey;

    public bool isCollide = false;
    private void OnTriggerEnter(Collider other)
    {
        isCollide = true;
        txtTakeKey.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        isCollide = false;
        txtTakeKey.SetActive(false);
    }
    private void Update()
    {
        if(isCollide && Input.GetKeyDown(KeyCode.E))
        {
            fakeKey.SetActive(false);
            keySound.Play();
            keyPanel1.GetComponent<Image>().sprite = keySprite;
            realKey.SetActive(true);
            txtTakeKey.SetActive(false);            
        }        
    }
}

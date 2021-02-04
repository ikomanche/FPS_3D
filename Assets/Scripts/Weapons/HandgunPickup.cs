using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandgunPickup : MonoBehaviour
{
    public GameObject realHandgun;
    public GameObject fakeHandgun;
    public AudioSource handguunPickupSound;
    public GameObject takeGunText;
    public GameObject collectMagText;
    public GameObject Player;
    public GameObject WeaponPanel;
    public Sprite pistolSprite;

    bool isCollide = false;
    private void Update()
    {
        if(isCollide && Input.GetKeyDown(KeyCode.E))
        {
            if (Player.transform.position.x < -3 && Player.transform.position.x > -4.101)
            {
                //realHandgun.SetActive(true);
                realHandgun.GetComponent<Item>().hasOwn = true;
                fakeHandgun.SetActive(false);
                handguunPickupSound.Play();
                GetComponent<BoxCollider>().enabled = false;
                isCollide = false;
                takeGunText.SetActive(false);
                //collectMagText.SetActive(true);
                StartCoroutine(MagTextAppear());
            }            
        }
        if(realHandgun.activeSelf)
        {
            WeaponPanel.GetComponent<Image>().sprite = pistolSprite;
        }
    }

    void OnTriggerEnter(Collider other)
    {           
        isCollide = true;
        takeGunText.SetActive(true);
    }

    IEnumerator MagTextAppear()
    {
        collectMagText.SetActive(true);
        yield return new WaitForSeconds(5); //anim takes 5 seconds
        collectMagText.SetActive(false);
    }
}

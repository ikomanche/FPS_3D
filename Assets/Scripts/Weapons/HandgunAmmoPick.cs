using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunAmmoPick : MonoBehaviour
{
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupSound;
    public GameObject fakeHandgun;
    public GameObject magBox;
    bool hasGun = false;

    void OnTriggerEnter(Collider other)
    {
        if (!fakeHandgun.activeSelf)
            hasGun = true;
    }

    private void Update()
    {
        if(hasGun)
        {
            fakeAmmoClip.SetActive(false);
            ammoPickupSound.Play();
            GlobalAmmo.handgunAmmo += 10;
            hasGun = false;
            magBox.SetActive(false);
        }        
    }
}

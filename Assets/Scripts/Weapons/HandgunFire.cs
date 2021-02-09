using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunFire : MonoBehaviour
{
    public GameObject bulletHole;
    public GameObject theGun;
    public GameObject muzzleFlash;
    public GameObject letterPanel;
    public GameObject inventoryPanel;
    public GameObject bagPanel;

    public AudioSource gunFire;
    public bool isFiring = false;
    public AudioSource emptySound;
    public GameObject Projectile;
    public Camera playerCamera;

    public float targetDistance;
    private int damageAmount;
    private float gunRange;
    public bool fireAnimAvailable = false;
    

    private void Start()
    {
        CharacterAim characterAim = GetComponent<CharacterAim>();
        characterAim.OnShoot += CharacterAim_OnShoot;
        damageAmount = GetComponent<Item>().Damage;
        gunRange = GetComponent<Item>().Range;
    }


    private void CharacterAim_OnShoot(object sender, CharacterAim.OnShootEventArgs e)
    {
        /*float dist = GetComponent<PlayerCasting>().toTarget;
        print(dist);*/
        GameObject bullet = Instantiate(Projectile, e.gunEndPointPosition, Quaternion.identity);
        bullet.transform.forward = playerCamera.transform.forward;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !letterPanel.activeSelf && !inventoryPanel.activeSelf && !bagPanel.activeSelf)
        {
            if(GlobalAmmo.handgunAmmo < 1)
            {
                emptySound.Play();
            }
            else
            {
                if (!isFiring)
                {
                    StartCoroutine(FiringHandgun());                    
                }
            }            
        }
    }
    IEnumerator FiringHandgun()
    {
        RaycastHit theShot;
        isFiring = true;
        GlobalAmmo.handgunAmmo -= 1;
        Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(rayOrigin, playerCamera.transform.forward,out theShot, gunRange))
        {
            targetDistance = theShot.distance;
            if(theShot.transform.tag == "Enemy" || theShot.transform.tag == "Player" || theShot.transform.tag == "Door")
            {
                theShot.transform.SendMessage("DamageEnemy", damageAmount, SendMessageOptions.DontRequireReceiver);
                theShot.transform.GetComponentInChildren<SoldierAI>().isHit = true;
            }
            else if(theShot.transform.tag == "EnemyHead")
            {
                print("HeadShot!!!!");
                theShot.transform.SendMessage("DamageEnemy", damageAmount * 3, SendMessageOptions.DontRequireReceiver);                
            }
            //if(Physics.Raycast(GetComponent<CharacterAim>().gunEnd.transform.position,playerCamera.transform.forward,out gun))
            //{
            //    if(gun.transform.tag != "Enemy" && gun.transform.tag != "Door")
            //    {
            //        Instantiate(bulletHole, gun.point, Quaternion.FromToRotation(Vector3.up, theShot.normal));
            //    }
            //}
            else
            {
                Instantiate(bulletHole, theShot.point, Quaternion.FromToRotation(Vector3.up, theShot.normal));
            }
        }
        theGun.GetComponent<Animator>().Play("HandgunFire");
        fireAnimAvailable = true;
        muzzleFlash.SetActive(true);
        gunFire.Play();
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.SetActive(false);
        fireAnimAvailable = false;
        yield return new WaitForSeconds(0.25f);        
        theGun.GetComponent<Animator>().Play("New State");
        isFiring = false;
    }  
}

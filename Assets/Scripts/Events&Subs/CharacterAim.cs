using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAim : MonoBehaviour
{
    public GameObject gunEnd;
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        //public float dist;
    }

    private Vector3 gunEndPos;
    private bool isFire, isAnimAvaible; // preventing bullet appearing (according to fire rate)
    private GameObject bullet;
    private GameObject cam;    
    private void Update()
    {
        isFire = GetComponent<HandgunFire>().isFiring;
        isAnimAvaible = GetComponent<HandgunFire>().fireAnimAvailable;
        if(isFire && isAnimAvaible && Input.GetButtonDown("Fire1"))
        {
            gunEndPos = gunEnd.transform.position;            
            OnShoot?.Invoke(this, new OnShootEventArgs { gunEndPointPosition = gunEndPos});            
        }
    }   
}

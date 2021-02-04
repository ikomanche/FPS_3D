using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public float lifeTime = 2f;
   // public Camera cam;
    //private double deflection = -0.05;
    private void Start()
    {
        transform.eulerAngles = GetComponent<HandgunFire>().playerCamera.transform.eulerAngles;
    }
    private void Update()
    {        
        //transform.position += new Vector3(-1, 0, 0);
        transform.position += transform.forward * speed * Time.deltaTime;        
               
        Destroy(gameObject,lifeTime); 
    }
}

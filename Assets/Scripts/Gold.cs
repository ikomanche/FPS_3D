using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{       

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            GlobalCash.cashValue += 400;
            gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }        
            
    }
}

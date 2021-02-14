using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SphereColliderEnemy : MonoBehaviour
{
    [SerializeField] private bool isCollide = false;
    [SerializeField] private GameObject AI;
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            player = other.gameObject;
            isCollide = true;
            if(!player.GetComponent<FirstPersonController>().isSneak)
            {
                AI.GetComponent<SoldierAI>().targetON = true;                
            }
        }
        if(other.transform.GetComponent<Item>().description == "Melee")
        {
            //do nothing
        }
    }

    private void Update()
    {
        if(isCollide)
        {
            if(!player.GetComponent<FirstPersonController>().isSneak && player.GetComponent<FirstPersonController>().soundON)
            {
                AI.GetComponent<SoldierAI>().targetON = true;
            }
            Debug.Log("capsule collider");
        }
    }
}

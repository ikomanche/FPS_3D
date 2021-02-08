using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierAI : MonoBehaviour
{
    public string hitTag;
    public bool lookingAtPlayer = false;
    public GameObject theSoldier;
    public AudioSource fireSound;
    public bool isFiring = false;
    public float fireRate = 1.5f;
    public int genHurt;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;
    private NavMeshAgent agent;
    public Transform destination;
    //private Vector3 initialPosition;
    //private Vector3 secondPos;
    //private Vector3 thirdPos;
    //private int destCount;

    private void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        //initialPosition = GetComponentInParent<Transform>().transform.position;
        //destCount = 0;
    }

    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            hitTag = Hit.transform.tag;         
        }
        if(hitTag == "Player" && !isFiring)
        {
            StartCoroutine(EnemyFire());
        }
        if(hitTag != "Player")
        {
            theSoldier.GetComponent<Animator>().Play("Walk");
            lookingAtPlayer = false;
        }
        agent.destination = destination.transform.position;
    }

    IEnumerator EnemyFire()
    {
        isFiring = true;
        theSoldier.GetComponent<Animator>().Play("FirePistol", -1,0);
        theSoldier.GetComponent<Animator>().Play("FirePistol");
        fireSound.Play();
        lookingAtPlayer = true;
        GlobalHealth.healthValue -= 7;
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hurtFlash.SetActive(false);
        genHurt = Random.Range(0, 3);
        hurtSound[genHurt].Play();
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}

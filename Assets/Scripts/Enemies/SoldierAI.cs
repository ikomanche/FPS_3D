using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierAI : MonoBehaviour
{    
    public string hitTag;
    public bool lookingAtPlayer = false, isFiring = false;
    public GameObject theSoldier, thePlayer;
    public AudioSource fireSound;    
    public float fireRate = 1.5f;
    private int genHurt;
    public AudioSource[] hurtSound;
    public GameObject hurtFlash;
    private NavMeshAgent agent;
    public Transform destination;
    private Animator animator;
    public bool isHit, targetON;
    public bool outOfRange;    
    private float range = 15f;

    private void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
        isHit = false;
        targetON = false;        
    }

    void Update()
    {
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.forward/*TransformDirection(Vector3.forward)*/, out Hit))
        {
            hitTag = Hit.transform.tag;         
        }
        if(hitTag == "Player" && !isFiring && !agent.GetComponent<EnemyDeath>().isDead)
        {
            targetON = true;
            if (Hit.distance > range)
                outOfRange = true;
            else
                outOfRange = false;
            //print(Hit.distance);
            if(!outOfRange)
                StartCoroutine(EnemyFire());
        }
        if(hitTag != "Player" && !targetON)
        {
            //theSoldier.GetComponent<Animator>().Play("Walk");
            lookingAtPlayer = false;
            agent.GetComponent<LookPlayer>().enabled = false;
        }
        if(!targetON)
        {
            agent.destination = destination.transform.position;
            if(isHit)
            {
                targetON = true;
            }
        }
            
        if(targetON)
        {
            if(!agent.GetComponent<EnemyDeath>().isDead)
            {
                agent.destination = thePlayer.transform.position;
                agent.GetComponent<LookPlayer>().enabled = true;                
                agent.GetComponent<NavMeshAgent>().speed = 0;                
                agent.GetComponent<NavMeshAgent>().stoppingDistance = range;
                if (outOfRange)
                {                    
                    agent.GetComponent<Animator>().Play("Run");
                    agent.GetComponent<NavMeshAgent>().speed = 7;
                    agent.GetComponent<NavMeshAgent>().acceleration = 25;
                }
                if (Hit.transform.tag != "Player")
                {                    
                    agent.GetComponent<Animator>().Play("Run");
                    agent.GetComponent<NavMeshAgent>().speed = 7;
                    agent.GetComponent<NavMeshAgent>().acceleration = 25;
                }
            }            
        }
    }

    public void HitByPlayer()
    {
        isHit = true;
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

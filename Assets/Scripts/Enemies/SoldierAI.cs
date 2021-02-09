using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldierAI : MonoBehaviour
{
    /// <summary>
    /// next day subject: Redesign this mess ! 
    /// Add chase shoot functions.
    /// 
    /// works but messy 9.2.21 2PM
    /// </summary>
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
    //private Vector3 initialPosition;
    //private Vector3 secondPos;
    //private Vector3 thirdPos;
    //private int destCount;
    private float range = 10f;

    private void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
        isHit = false;
        targetON = false;
        //initialPosition = GetComponentInParent<Transform>().transform.position;
        //destCount = 0;
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
            
        else if(targetON)
        {
            if(!agent.GetComponent<EnemyDeath>().isDead)
            {
                agent.destination = thePlayer.transform.position;
                agent.GetComponent<LookPlayer>().enabled = true;
                agent.GetComponent<NavMeshAgent>().speed = 2;
                agent.GetComponent<NavMeshAgent>().stoppingDistance = range;
                if (outOfRange)
                {                    
                    agent.GetComponent<Animator>().Play("Run");
                    agent.GetComponent<NavMeshAgent>().speed = 7;
                    agent.GetComponent<NavMeshAgent>().acceleration = 25;
                }
                if (Hit.transform.tag != "Player")
                {
                    //agent.GetComponent<LookPlayer>().enabled = false;
                    agent.GetComponent<Animator>().Play("Run");
                    agent.GetComponent<NavMeshAgent>().speed = 7;
                    agent.GetComponent<NavMeshAgent>().acceleration = 25;
                }
                //agent.GetComponent<Animator>().Play("Run");
                //if(Hit.distance == 10)
                //{
                //    agent.GetComponent<Animator>().Play("FirePistol",-1,0)
                //}
                
            }            
        }
        //if(!targetON || !isHit)
        //{
        //    agent.GetComponent<LookPlayer>().enabled = true;
        //    agent.destination = destination.transform.position;
        //    animator.Play("Walk");
        //}
        //else if(targetON || isHit)
        //{
        //    agent.GetComponent<NavMeshAgent>().stoppingDistance = 10;
        //    agent.destination = thePlayer.transform.position;
        //}

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

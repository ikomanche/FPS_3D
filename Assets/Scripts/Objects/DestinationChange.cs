using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestinationChange : MonoBehaviour
{
    private int count = 0;
    private GameObject theEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {            
            theEnemy = other.gameObject;
            StartCoroutine(IdleAnim());
            if (this.gameObject.name == "Dest1")
            {
                if (count % 3 == 0)
                {
                    this.gameObject.transform.position = new Vector3(-5.16f, 1f, 36.64f);
                    count++;
                }
                else if (count % 3 == 1)
                {
                    this.gameObject.transform.position = new Vector3(-13.17f, 1f, 36.01f);
                    count++;
                }
                else
                {
                    this.gameObject.transform.position = new Vector3(-8.09f, 1f, 26.3f);
                    count++;
                }
            }
            else
            {
                if (count % 2 == 0)
                {
                    this.gameObject.transform.position = new Vector3(-22.769f,1,23.633f);
                    count++;
                }
                else
                {
                    this.gameObject.transform.position = new Vector3(-22.769f,1,-11.26f);
                    count++;
                }
            }
        }
    }

    IEnumerator IdleAnim()
    {
        theEnemy.GetComponent<NavMeshAgent>().speed = 0;
        theEnemy.GetComponent<Animator>().Play("Idle");
        yield return new WaitForSeconds(3f);
        theEnemy.GetComponent<NavMeshAgent>().speed = 2;
        theEnemy.GetComponent<Animator>().Play("Walk");
    }
}

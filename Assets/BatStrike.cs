using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStrike : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public AudioSource hurlSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !panel1.activeSelf && !panel2.activeSelf && !panel3.activeSelf)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        GetComponent<Animator>().Play("BatAttack");
        hurlSound.Play();
        yield return new WaitForSeconds(0.7f);
        GetComponent<Animator>().Play("New State");
    }

}

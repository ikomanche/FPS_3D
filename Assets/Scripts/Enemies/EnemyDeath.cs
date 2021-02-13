using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyDeath : MonoBehaviour
{
    public int enemyHealth = 100;
    public bool isDead = false;
    public GameObject enemyAI;
    public GameObject theEnemy;
    [SerializeField] BoxCollider box;

    public Slider healthbarSlider;
    public Gradient hbGradient;
    public GameObject healthBar;
    public Image fill;
    public GameObject bag;

    void DamageEnemy(int damageAmount)
    {
        enemyHealth -= damageAmount;
        healthbarSlider.value = enemyHealth;
        fill.color = hbGradient.Evaluate(healthbarSlider.normalizedValue);
    }

    private void Start()
    {
        healthbarSlider.maxValue = enemyHealth;
        healthbarSlider.value = enemyHealth;

        fill.color = hbGradient.Evaluate(1f);        
    }    

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<Item>().description == "Melee")
        {
            enemyHealth = 0;
            GetComponent<NavMeshAgent>().speed = 0;
        }
            
    }

    void Update()
    {
        if(enemyHealth <= 0 && !isDead)
        {
            isDead = true;
            GetComponent<BoxCollider>().enabled = false;
            theEnemy.GetComponent<Animator>().Play("Death");
            enemyAI.SetActive(false);
            theEnemy.GetComponent<LookPlayer>().enabled = false;
            healthBar.SetActive(false);
            bag.SetActive(true);
            GlobalCash.cashValue += 300;
        }
    }
}

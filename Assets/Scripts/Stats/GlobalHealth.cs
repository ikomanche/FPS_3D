using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    public GameObject healthDisplay;
    public static int healthValue;
    public int internalHealth;

    private void Start()
    {
        healthValue = 1000;
    }

    void Update()
    {
        if(healthValue <= 0)
        {
            SceneManager.LoadScene(0);
        }
        internalHealth = healthValue;
        healthDisplay.GetComponent<Text>().text = "" + healthValue + "%";
    }
}

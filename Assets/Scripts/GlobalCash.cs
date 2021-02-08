using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCash : MonoBehaviour
{
    public GameObject icon;
    public GameObject value;
    public int internalCash;
    public static int cashValue = 0;

    private void Start()
    {
        internalCash = 0;
    }

    private void Update()
    {
        if(cashValue != internalCash)
        {
            StartCoroutine(CashAnim());
        }
        internalCash = cashValue;
        value.GetComponent<Text>().text = "" + internalCash;
    }

    IEnumerator CashAnim()
    {
        icon.GetComponent<Animator>().Play("CashGained");
        yield return new WaitForSeconds(1);
        icon.GetComponent<Animator>().Play("New State");
    }
}

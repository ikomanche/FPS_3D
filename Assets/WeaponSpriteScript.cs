using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSpriteScript : MonoBehaviour
{
    [SerializeField] GameObject Handgun;
    [SerializeField] GameObject Bat;

    private void Update()
    {
        if (Handgun.activeSelf)
        {
            GetComponent<Image>().sprite = Handgun.GetComponent<Item>().icon;
        }
        if (Bat.activeSelf)
        {
            GetComponent<Image>().sprite = Bat.GetComponent<Item>().icon;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenFinal : MonoBehaviour
{
    [SerializeField] private GameObject _theDoorLeft;
    [SerializeField] private GameObject _theDoorRight;
    [SerializeField] private GameObject _theKey;
    [SerializeField] private GameObject fadeOut;
    [SerializeField] private GameObject completePanel;
    [SerializeField] private bool isCollite = false;
    [SerializeField] private bool Complete = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            isCollite = true;
        }
    }

    private void Update()
    {
        if(isCollite && Input.GetKeyDown(KeyCode.E) && _theKey.activeSelf)
        {
            _theDoorLeft.GetComponent<Animator>().Play("FinalDoorLeft");
            _theDoorRight.GetComponent<Animator>().Play("FinalDoorRight");
            Complete = true;
        }
        if(Complete)
        {
            StartCoroutine(FadeOut());
            StartCoroutine(Panel());
            
        }
    }

    IEnumerator Panel()
    {
        yield return new WaitForSeconds(2);
        completePanel.SetActive(true);
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
    }
}

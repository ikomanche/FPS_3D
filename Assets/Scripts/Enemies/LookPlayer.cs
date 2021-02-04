using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{
    public Transform thePlayer;

    private void Update()
    {
        transform.LookAt(thePlayer);
    }
}

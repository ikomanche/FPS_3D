using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSoldier : MonoBehaviour
{
    [SerializeField] SoldierAI AI;
    [SerializeField] private bool start = false;

    private void Start()
    {
        AI.enabled = false;
    }

    public void BeginPatrol()
    {
        start = true;
        AI.enabled = true;
    }
}

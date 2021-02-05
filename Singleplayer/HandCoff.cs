using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandCoff : MonoBehaviour
{
    public NavMeshAgent agent;
    public NavmashCOntrolThief navmashCOntrolThief;

    void OnEnable()
    {
        agent.enabled = false;
        navmashCOntrolThief.enabled = false;
    }

    private void OnDisable()
    {
        agent.enabled = true;
        navmashCOntrolThief.enabled = true;
    }
}

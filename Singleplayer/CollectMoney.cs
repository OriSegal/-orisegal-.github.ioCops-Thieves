using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectMoney : MonoBehaviour
{
    private NavMeshAgent agent;
    private ClosesT closest;
    NavmashCOntrolThief navmashCOntrolThief;




    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        closest = GetComponent<ClosesT>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        navmashCOntrolThief = GetComponent<NavmashCOntrolThief>();
    }


    void Update()
    {
        if(closest.Moneytraget != null)
        {
            agent.SetDestination(closest.Moneytraget.transform.position);
        }
    }
}

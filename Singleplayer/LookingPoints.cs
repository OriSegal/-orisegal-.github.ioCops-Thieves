using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookingPoints : MonoBehaviour
{
    private NavMeshAgent agent;
    ClosesT closest;
    CollectMoney collectMoney;
    LookingPoints Lookingpoints;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        closest = GetComponent<ClosesT>();
        collectMoney = GetComponent<CollectMoney>();
        Lookingpoints = GetComponent<LookingPoints>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(closest.Point.transform.position);
        if(agent.destination.x == transform.position.x)
        {
            collectMoney.enabled = true;
            Lookingpoints.enabled = false;
        }
    }
}

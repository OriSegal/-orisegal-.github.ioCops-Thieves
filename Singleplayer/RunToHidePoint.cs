using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunToHidePoint : MonoBehaviour
{
    private NavMeshAgent agent;
    private ClosesT closest;
    private CollectMoney collectMoney;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        closest = GetComponent<ClosesT>();
        collectMoney = GetComponent<CollectMoney>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }


    void Update()
    {
        agent.SetDestination(closest.HidePoint.transform.position);
    }

    void OnDisable()
    {
        collectMoney.enabled = true;
    }
}

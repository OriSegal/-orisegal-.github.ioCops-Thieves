using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseThieves : MonoBehaviour
{
    [SerializeField]
    private GameObject Thief;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        
        agent.SetDestination(Thief.transform.position);
    }
}

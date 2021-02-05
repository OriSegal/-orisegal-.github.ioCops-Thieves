using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseDonut : MonoBehaviour
{
    private GameObject PinkDount;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    void Update()
    {
        if (PinkDount == null)
        {
            PinkDount = GameObject.FindGameObjectWithTag("Money");
        }

        if(Vector2.Distance(transform.position, PinkDount.transform.position) < 35)
        {
            agent.SetDestination(PinkDount.transform.position);
        }
    }
}

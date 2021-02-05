using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    [SerializeField]
    List<GameObject> PatrolList;
    private NavMeshAgent agent;
    [SerializeField]
    private int CurrentPatrolIndex = 0;
    private bool IsMoveing = true;
    private int PatrolCount;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        IsMoveing = true;
        Debug.Log(PatrolList.Count);
        PatrolCount = PatrolList.Count;
    }


    void Update()
    {
        if(agent.remainingDistance < 2f && IsMoveing == true)
        {
            IsMoveing = false;
        } 
        
        if(IsMoveing == false)
        {
            SetDIstanition();
            CurrentPatrolIndex = Random.Range(0, PatrolCount);
            IsMoveing = true;
        }
    }

    void SetDIstanition()
    {
        Vector2 DistancePoint = PatrolList[CurrentPatrolIndex].transform.position;
        agent.SetDestination(DistancePoint);
        
    }
}

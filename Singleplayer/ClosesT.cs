using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClosesT : MonoBehaviour
{
    
    public GameObject Moneytraget;
    public GameObject Point;
    public GameObject NPC;
    public GameObject HidePoint;

    void Update()
    {
        FindClosestMoney();
        FindClosestPoint();
        FindClosestNPC();
        FindClosestHide();
    }

    void FindClosestMoney()
    {
        float distanceToClosestmoney = Mathf.Infinity;
        GameObject closestmoney = null;
        GameObject[] allmoney = GameObject.FindGameObjectsWithTag("Money");

        foreach (GameObject currentEnemy in allmoney)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestmoney)
            {
                distanceToClosestmoney = distanceToEnemy;
                closestmoney = currentEnemy;
                Moneytraget = closestmoney;
            }
        }
        Debug.DrawLine(this.transform.position, closestmoney.transform.position);
    }

    void FindClosestPoint()
    {
        float distanceToClosestpoint = Mathf.Infinity;
        GameObject closestpoint = null;
        GameObject[] allpoints = GameObject.FindGameObjectsWithTag("FreePoint");

        foreach (GameObject currentEnemy in allpoints)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestpoint)
            {
                distanceToClosestpoint = distanceToEnemy;
                closestpoint = currentEnemy;
                Point = closestpoint;
            }
        }
        Debug.DrawLine(this.transform.position, closestpoint.transform.position);
    }

    void FindClosestNPC()
    {
        float distanceToClosestNPC = Mathf.Infinity;
        GameObject closestnpc = null;
        GameObject[] allnpc = GameObject.FindGameObjectsWithTag("ThiefNPC");

        foreach (GameObject currentEnemy in allnpc)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestNPC && currentEnemy.transform.position != transform.position)
            {
                distanceToClosestNPC = distanceToEnemy;
                closestnpc = currentEnemy;
                NPC = closestnpc;
            }
        }
        Debug.DrawLine(this.transform.position, closestnpc.transform.position);
    }

    void FindClosestHide()
    {
        float distanceToClosestHide = Mathf.Infinity;
        GameObject closestHide = null;
        GameObject[] allHidePoint = GameObject.FindGameObjectsWithTag("HidePoint");

        foreach (GameObject currentEnemy in allHidePoint)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestHide && currentEnemy.transform.position != transform.position)
            {
                distanceToClosestHide = distanceToEnemy;
                closestHide = currentEnemy;
                HidePoint = closestHide;
            }
        }
        Debug.DrawLine(this.transform.position, closestHide.transform.position);
    }

}

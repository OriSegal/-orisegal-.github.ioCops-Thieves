using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavmashControl : MonoBehaviour
{
    [SerializeField]
    private GameObject Thief;
    private ChaseThieves chasethieves;
    private PatrolAI patrolAI;
    [SerializeField]
    private int RangeToChase = 15;

    public GameObject Throwable;
    public GameObject InvisibilityObj;


    private bool PinkDonut = false;
   

    void Start()
    {
        chasethieves = GetComponent<ChaseThieves>();
        patrolAI = GetComponent<PatrolAI>();
    }


    void Update()
    {
        if (InvisibilityObj.active)
        {
            RangeToChase = 0;
        }
        else
        {
            RangeToChase = 15;
        }

        ThrowToCatch();
        if (Vector2.Distance(transform.position, Thief.transform.position) < RangeToChase)
        {
            chasethieves.enabled = true;
            patrolAI.enabled = false;
        }
        else
        {
            chasethieves.enabled = false;
            patrolAI.enabled = true;
        }
    }

    void ThrowToCatch()
    {
        if (Vector2.Distance(transform.position, Thief.transform.position) < 4)
        {
            Instantiate(Throwable, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Donut")
        {
            PinkDonut = true;
        }
    }
}

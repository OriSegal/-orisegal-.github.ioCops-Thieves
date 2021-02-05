using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmashCOntrolThief : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject CopNpc;
    private Rigidbody2D rigidbody2D;
    CollectMoney collectMoney;
    LookingPoints Lookingpoints;
    RunToHidePoint runToHidePoint;
    ClosesT closest;
    public GameObject Handcoff;
    [SerializeField]
    private GameObject Cop;
    public int DistanceForHide = 25;
    public int DistanceForRun = 8;
    public GameObject Jail;
    [SerializeField]
    private bool SwitcherOn = true;
    public Collider2D collider2D;
    [SerializeField]
    private bool close = false;
    public GameObject ArrestEffect;
    public GameObject Pip1;
    public GameObject Pip3;
    public GameObject Pip5;
    public GameObject Pip7;
    public GameObject Pip8;
    public GameObject Pip9;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rigidbody2D = GetComponent<Rigidbody2D>();
        CopNpc = GameObject.FindGameObjectWithTag("CopNpc");
        Cop = GameObject.FindGameObjectWithTag("Cop");
        collectMoney = GetComponent<CollectMoney>();
        Lookingpoints = GetComponent<LookingPoints>();
        closest = GetComponent<ClosesT>();
        runToHidePoint = GetComponent<RunToHidePoint>();

        Pip1 = GameObject.FindGameObjectWithTag("PipeCover1");
        Pip3 = GameObject.FindGameObjectWithTag("PipeCover3");
        Pip5 = GameObject.FindGameObjectWithTag("PipeCover5");
        Pip7 = GameObject.FindGameObjectWithTag("PipeCover7");
        Pip8 = GameObject.FindGameObjectWithTag("PipeCover8");
        Pip9 = GameObject.FindGameObjectWithTag("PipeCover9");
    }


    void Update()
    {
        PipeControl();
        Vector2 RunAway = transform.position - Cop.transform.position;
        if (SwitcherOn && collectMoney.enabled == true)
        {
            StartCoroutine(Switcher());
        }
        if (Vector2.Distance(transform.position, Cop.transform.position) < DistanceForHide && close == false)
        {
            agent.enabled = true;
            runToHidePoint.enabled = true;
            collectMoney.enabled = false;
            Lookingpoints.enabled = false;          
        }
        else if(Vector2.Distance(transform.position, Cop.transform.position) > DistanceForHide)
        {
            runToHidePoint.enabled = false;
        }

        if (Vector2.Distance(transform.position, Cop.transform.position) < DistanceForRun)
        {
            close = true;
            agent.enabled = false;
            transform.Translate(RunAway.normalized * agent.speed * Time.deltaTime);
        }
        else
        {
            close = false;
        }

        Vector2 RunAwayNPC = transform.position - closest.NPC.transform.position;
        if (Vector2.Distance(transform.position, closest.NPC.transform.position) < 5)
        {
            agent.enabled = false;
            transform.Translate(RunAwayNPC.normalized * agent.speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, closest.NPC.transform.position) < 15)
        {
            agent.enabled = true;
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CopNpc")
        {
            Handcoff.SetActive(true);
        }

        if(collision.gameObject.tag == "Trap")
        {
            agent.speed = agent.speed - 4;
            Invoke("StopDonutEffect", 7);
        }

        if(collision.gameObject.tag == "ThiefNPC")
        {
            collider2D.enabled = false;
            agent.radius = 0.1f;
        }
        if(collision.gameObject.tag == "Jail")
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ThiefNPC")
        {
            collider2D.enabled = true;
            agent.radius = 1.5f;
        }
    }

    void StopDonutEffect()
    {
        agent.speed = agent.speed + 4;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Thief" && FindObjectOfType<ThiefPlayer>().Hit == true)
        {
            Handcoff.SetActive(false);
            FindObjectOfType<SingleGameManager>().MoneyCollected = FindObjectOfType<SingleGameManager>().MoneyCollected - 500;
        }

        if (collision.gameObject.tag == "Cop" && FindObjectOfType<CopPlayer>().Chatch == true)
        {
            agent.enabled = false;
            Instantiate(ArrestEffect, this.transform.position, Quaternion.identity);
            transform.position = Vector2.MoveTowards(transform.position, Jail.transform.position, 500);
        }
    }

    void PipeControl()
    {
        if (Pip1 == null)
        {
            return;
        }
        else if(Vector2.Distance(transform.position, Pip1.transform.position) < 4 && Pip1 != null)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip3.transform.position, 300 + Time.deltaTime);
        }

        if (Pip3 == null)
        {
            return;
        }
        else if(Vector2.Distance(transform.position, Pip3.transform.position) < 4 && Pip3 != null)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip1.transform.position, 300 + Time.deltaTime);
        }

        if (Pip5 == null)
        {
            return;
            
        }
        else if(Vector2.Distance(transform.position, Pip5.transform.position) < 4 && Pip5 != null)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip7.transform.position, 300 + Time.deltaTime);
        }

        if (Pip7 == null)
        {
            return;
        }
        else if(Vector2.Distance(transform.position, Pip7.transform.position) < 4 && Pip7 != null)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip5.transform.position, 300 + Time.deltaTime);
        }

        if (Pip8 == null)
        {
            return;
        }
        else if (Vector2.Distance(transform.position, Pip8.transform.position) < 4 && Pip7 != null)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip9.transform.position, 300 + Time.deltaTime);
        }

        if (Pip9 == null)
        {
            return;
        }
        else if (Vector2.Distance(transform.position, Pip9.transform.position) < 4 && Pip7 != null)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip8.transform.position, 300 + Time.deltaTime);
        }

    }

    IEnumerator Switcher()
    {
        SwitcherOn = false;
        int RandomTimeToPoint = Random.Range(5, 25);

        yield return new WaitForSeconds(RandomTimeToPoint);
        collectMoney.enabled = false;
        Lookingpoints.enabled = true;

        SwitcherOn = true;
    }

}

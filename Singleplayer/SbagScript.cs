using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SbagScript : MonoBehaviour
{
    public float TimeToOpen = 300;
    public Slider slider;
    private GameObject Thief;
    private GameObject E;
    public GameObject Effect;


    void Start()
    {
        Invoke("DestroyObject", 30);
        Thief = GameObject.FindGameObjectWithTag("Thief");
        FindClosestE();
        if (Vector2.Distance(transform.position, E.transform.position) < 5)
        {
            Destroy(this.gameObject);
        }
    }


    void Update()
    {
        slider.value = TimeToOpen;
        if(Thief != null)
        {
            if (Vector2.Distance(transform.position, Thief.transform.position) < 3 && FindObjectOfType<ThiefPlayer>().Hit == true)
            {
                TimeToOpen = TimeToOpen - 2;
                if (FindObjectOfType<ThiefPlayer>().Slight == true)
                {
                    TimeToOpen = TimeToOpen - 2 * 5;
                }
            }
        }

        if (TimeToOpen < 1)
        {
            FindObjectOfType<SingleGameManager>().MoneyCollected = FindObjectOfType<SingleGameManager>().MoneyCollected + 500;
            Instantiate(Effect, this.transform.position, Quaternion.identity);
            DestroyObject();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ThiefNPC")
        {
            TimeToOpen = TimeToOpen - 1f;
        }

        if (collision.gameObject.tag == "E")
        {
            DestroyObject();
            Debug.Log("MoneyOnBulding");
        }
    }



    void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    void FindClosestE()
    {
        float distanceToClosestHide = Mathf.Infinity;
        GameObject closestHide = null;
        GameObject[] allHidePoint = GameObject.FindGameObjectsWithTag("E");

        foreach (GameObject currentEnemy in allHidePoint)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestHide && currentEnemy.transform.position != transform.position)
            {
                distanceToClosestHide = distanceToEnemy;
                closestHide = currentEnemy;
                E = closestHide;
            }
        }
        Debug.DrawLine(this.transform.position, closestHide.transform.position);
    }
}

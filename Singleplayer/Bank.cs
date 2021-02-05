using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{
    public Image Dot1;
    public Image Dot2;
    public Image Dot3;
    public Slider slider;
    private GameObject Thief;
    public float TimeToOpen = 5000;

    private int LocksToOpen = 0;

    void Start()
    {
        Thief = GameObject.FindGameObjectWithTag("Thief");
    }


    void Update()
    {
        slider.value = TimeToOpen;
        if (Thief != null)
        {
            if (Vector2.Distance(transform.position, Thief.transform.position) < 8 && FindObjectOfType<ThiefPlayer>().Hit == true && LocksToOpen == 3)
            {
                TimeToOpen = TimeToOpen - 2;
                if (FindObjectOfType<ThiefPlayer>().Slight == true)
                {
                    TimeToOpen = TimeToOpen - 2 * 2;
                }
            }
        }

        if(TimeToOpen < 1)
        {
            FindObjectOfType<SingleGameManager>().MoneyCollected = 100000;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Thief" && FindObjectOfType<CarryKeys>().Key1 == true)
        {
            FindObjectOfType<CarryKeys>().Key1 = false;
            Dot1.color = Color.green;
            LocksToOpen++;
        }

        if (collision.gameObject.tag == "Thief" && FindObjectOfType<CarryKeys>().Key2 == true)
        {
            FindObjectOfType<CarryKeys>().Key2 = false;
            Dot2.color = Color.green;
            LocksToOpen++;
        }

        if (collision.gameObject.tag == "Thief" && FindObjectOfType<CarryKeys>().Key3 == true)
        {
            FindObjectOfType<CarryKeys>().Key3 = false;
            Dot3.color = Color.green;
            LocksToOpen++;
        }
    }
}

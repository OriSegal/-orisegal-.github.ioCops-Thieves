using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SAtm : MonoBehaviour
{
    public float TimeToOpen = 1000;
    public Slider slider;
    private GameObject Thief;
    public GameObject Effect;

    void Start()
    {
        Thief = GameObject.FindGameObjectWithTag("Thief");
    }


    void Update()
    {
        slider.value = TimeToOpen;
        if (Thief != null)
        {
            if (Vector2.Distance(transform.position, Thief.transform.position) < 4 && FindObjectOfType<ThiefPlayer>().Hit == true)
            {
                TimeToOpen = TimeToOpen - 2;
                if (FindObjectOfType<ThiefPlayer>().Slight == true)
                {
                    TimeToOpen = TimeToOpen - 2 * 3;
                }
            }
        }

        if (TimeToOpen < 1)
        {
            FindObjectOfType<SingleGameManager>().MoneyCollected = FindObjectOfType<SingleGameManager>().MoneyCollected + 2500;
            Instantiate(Effect, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

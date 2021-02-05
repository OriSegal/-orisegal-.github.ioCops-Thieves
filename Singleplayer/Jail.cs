using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ThiefNPC")
        {
            FindObjectOfType<SingleGameManager>().ThievesInJail = FindObjectOfType<SingleGameManager>().ThievesInJail + 1;
        }
        if(collision.gameObject.tag == "Thief")
        {
            FindObjectOfType<SingleGameManager>().ThievesInJail = FindObjectOfType<SingleGameManager>().ThievesInJail + 1;
        }
    }
}

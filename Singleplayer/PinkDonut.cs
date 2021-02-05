using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkDonut : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cop")
        {
            Destroy(gameObject);
            Debug.Log("Hi");
        }
    }
}

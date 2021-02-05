using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkDonut1 : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyObject", 30);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cop")
        {
            Destroy(this.gameObject);
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}

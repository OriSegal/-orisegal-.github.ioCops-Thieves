using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Trowhable : NetworkBehaviour
{

    private GameObject Thief;
 
    void Start()
    {
        Invoke("DestroyThis", 0.5f);
        Thief = GameObject.FindGameObjectWithTag("Thief");
    }

    void DestroyThis()
    {
        NetworkServer.Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position,Thief.transform.position) < 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, Thief.transform.position, 500);
        }
    }

}

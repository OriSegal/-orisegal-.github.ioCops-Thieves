using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DountToRight : NetworkBehaviour
{

    public int speed = 1000;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Thief")
        {
            NetworkServer.Destroy(this.gameObject);
        }
    }


}

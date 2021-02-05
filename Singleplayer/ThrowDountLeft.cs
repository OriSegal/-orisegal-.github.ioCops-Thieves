using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDountLeft : MonoBehaviour
{
    public int speed = 1000;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Invoke("DestroyAfter3s", 3);
    }


    void FixedUpdate()
    {
        rigidbody2D.velocity = Vector2.left * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ThiefNPC")
        {
            Destroy(this.gameObject);
        }
    }

    void DestroyAfter3s()
    {
        Destroy(this.gameObject);
    }
}

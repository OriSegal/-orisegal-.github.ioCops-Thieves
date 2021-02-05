using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TrapScript : NetworkBehaviour
{

    
    void Start()
    {
        Invoke("DestroyTrap", 30);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Thief")
        {
            
            NetworkServer.Destroy(this.gameObject.gameObject);
        }
    }

    void DestroyTrap()
    {
        NetworkServer.Destroy(this.gameObject.gameObject);
    }
}

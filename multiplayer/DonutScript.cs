using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class DonutScript : NetworkBehaviour
{
     void Start()
    {
        Invoke("CmdDestroyDount", 30);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cop")
        {
            CmdDestroyDount();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Cop")
        {
            NetworkServer.Destroy(this.gameObject);
        }
    }

    [Command]
    void CmdDestroyDount()
    {
        NetworkServer.Destroy(this.gameObject);
    }
}

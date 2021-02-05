using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PresonerManager : NetworkBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Thief")
        {
            CmdLockUp();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Thief")
        {
            CmdLockDwon();
        }
    }

    [Command]
    void CmdLockUp()
    {
        RpcLockUp();
    }
    [ClientRpc]
    void RpcLockUp()
    {
        FindObjectOfType<GameManager>().ThiefToLock = FindObjectOfType<GameManager>().ThiefToLock + 1;
    }

    [Command]
    void CmdLockDwon()
    {
        RpcLockdwon();
    }
    [ClientRpc]
    void RpcLockdwon()
    {
        FindObjectOfType<GameManager>().ThiefToLock = FindObjectOfType<GameManager>().ThiefToLock - 1;
    }
}

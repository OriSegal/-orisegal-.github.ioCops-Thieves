using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SmallMoney : NetworkBehaviour
{
    [SyncVar]
    public float TimeToOpen = 100;
    public GameObject MoneyCollected;

    void Start()
    {
        Invoke("CmdDestroyMoney", 30);
    }

    void FixedUpdate()
    {
        if (TimeToOpen < 0)
        {
            Invoke("CmdDestroyMoney", 0.2f);
            MoneyCollected.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject Thief = GameObject.FindGameObjectWithTag("Thief");
        if (collision.gameObject.tag == "Thief")
        {
            CmdTimeToOpen();
        }
    }

    void OnDestroy()
    {
        if (TimeToOpen < 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money + 200;
        }
    }

    [Command]
    void CmdDestroyMoney()
    {
        NetworkServer.Destroy(this.gameObject);

    }

    [Command]
    void CmdTimeToOpen()
    {
        RpcTimeToOpen();
    }
    [ClientRpc]
    void RpcTimeToOpen()
    {
        TimeToOpen = TimeToOpen - 35 * Time.deltaTime;
    }
}

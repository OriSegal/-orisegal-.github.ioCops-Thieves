using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class MoneyScript : NetworkBehaviour
{
    [SyncVar]
    public float TimeToOpen = 100;
    public GameObject MoneyCollected;

    void Start()
    {
        Invoke("DestroyMoney", 30);
    }

    void FixedUpdate()
    {
      if(TimeToOpen < 0)
        {
            Invoke("DestroyMoney", 0.2f);
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
        if(TimeToOpen < 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money + 500;
        }
    }

    
    void DestroyMoney()
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
        TimeToOpen = TimeToOpen - 15 * Time.deltaTime;
    }
}

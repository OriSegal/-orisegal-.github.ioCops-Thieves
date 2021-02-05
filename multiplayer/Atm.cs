using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Atm : NetworkBehaviour
{
    [SyncVar]
    public float TimeToOpen = 1000;
    public bool ReadyToOpen = false;
    public GameObject MoneySound;

    void FixedUpdate()
    {
        if (TimeToOpen < 0)
        {
            MoneySound.SetActive(true);
            Invoke("DestroyAtm", 0.3f);
        }
    }

    void OnDestroy()
    {
        if(TimeToOpen <= 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money + 1500;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Thief")
        {
            CmdTimeToOpen();
        }
    }



    void DestroyAtm()
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
        TimeToOpen = TimeToOpen - 40 * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpwanTrap : NetworkBehaviour
{
    //public GameObject Trap;
    public GameObject DountRight;
    public GameObject DountLeft;
    public GameObject Trowhable;

    //public bool TrapSet = true;
    public Text CopButtonText;

    CopScripte copScripte;

    void Start()
    {
        copScripte = GetComponent<CopScripte>();
    }


    public void OnSpwanTrap()
    {
        //if(TrapSet == true)
        {
            //GameObject SpwanTrap = Instantiate(Trap, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
            //NetworkServer.Spawn(SpwanTrap);
        }

        //if (isLocalPlayer)
        {         
           //Invoke("SetTrap", 30);
           //TrapSet = false;
           //CopButtonText.color = Color.white;
        }      
    }

    public void OnTrohwable()
    {
        CmdTrhowable();
    }


    public void ShootRight()
    {
        if (isLocalPlayer && copScripte.Lodedd == true)
        {
            if (copScripte.MoveH > 0)
            {
                CmdDountRight();
            }

            if (copScripte.MoveH < 0)
            {
                CmdDountLeft();
            }

            if (copScripte.MoveH == 0)
            {
                CmdDountRight();
            }
        }
    }

    void SetTrap()
    {
        //if (isLocalPlayer)
        {
            //TrapSet = true;
            //CopButtonText.color = new Color(9.0f / 255.0f, 5.0f / 255.0f, 105.0f / 255.0f);
        }
    }

    

    void OnDestroy()
    {
        if (isLocalPlayer)
        {
            Cmda();
        }
    }

    [Command]
    void CmdSetTrap()
    {
        ///GameObject SpwanTrap = Instantiate(Trap, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
        //NetworkServer.Spawn(SpwanTrap);
    }

    [Command]
    void CmdTrhowable()
    {
        GameObject SpwanTrowhable = Instantiate(Trowhable, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        NetworkServer.Spawn(SpwanTrowhable);
    }

    [Command]
    void CmdDountRight()
    {
        GameObject SpwanDountRight = Instantiate(DountRight, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
        NetworkServer.Spawn(SpwanDountRight);
    }

    [Command]
    void CmdDountLeft()
    {
        GameObject SpwanDountLeft = Instantiate(DountLeft, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
        NetworkServer.Spawn(SpwanDountLeft);
    }

    [Command]
    void Cmda()
    {
        Rpca();
    }
    [ClientRpc]
    void Rpca()
    {
        FindObjectOfType<GameManager>().CopsNumber--;
    }

}

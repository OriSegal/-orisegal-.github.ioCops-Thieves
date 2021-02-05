using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Networking.Match;
using UnityEngine.Advertisements;

public class PlayerUI : NetworkBehaviour
{
    public GameObject RelesasesMenu;
    public GameObject[] PresonerBottoms;
    public Text Botton1;
    public Text Botton2;
    public Text Botton3;
    public Text Botton4;
    public Text Botton5;
    public Text Botton6;
    [SerializeField]
    GameObject Manu;

    public Text MoneyCollected;
    public Text NumberOfThiefs;
    public Text NumberOfPresoners;
    public AudioSource Click;


    private NetworkManager networkmanager;


    void Start()
    {
        networkmanager = NetworkManager.singleton;
        Advertisement.Initialize("3938179", true);
    }

    public void OnLeaveGame()
    {
        if (isLocalPlayer)
        {
            if (!isClient)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
                Click.Play();
                MatchInfo matchInfo = networkmanager.matchInfo;
                networkmanager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkmanager.OnDropConnection);
                networkmanager.StopHost();
            }

            if (isClient)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
                Click.Play();
                MatchInfo matchInfo = networkmanager.matchInfo;
                networkmanager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkmanager.OnDropConnection);
                networkmanager.StopClient();
            }
        }
    }

    public void OpenRelesasesMenu()
    {
        GameObject Prison = GameObject.FindGameObjectWithTag("Prison");
        if (Vector2.Distance(transform.position, Prison.transform.position) < 5 && GetComponent<ThiefScripte>().enabled == true)
        {
            Click.Play();
            RelesasesMenu.SetActive(true);
        }
    }

    public void CloseRelesaseMenu()
    {
        Click.Play();
        RelesasesMenu.SetActive(false);
    }

    void FixedUpdate()
    {

        MoneyCollected.text = FindObjectOfType<GameManager>().Money.ToString() + "/10000";
        NumberOfThiefs.text = FindObjectOfType<GameManager>().ThiefNumber.ToString();
        NumberOfPresoners.text = FindObjectOfType<GameManager>().ThiefToLock.ToString() + "/";
            for (int i = 0; i < FindObjectOfType<GameManager>().SomeOneInJail; i++)
            {
                PresonerBottoms[i].SetActive(true);
            }

            if (FindObjectOfType<GameManager>().SomeOneInJail == 1)
            {
                Botton1.text = FindObjectOfType<GameManager>().CurrentPresoner;
            }
            if (FindObjectOfType<GameManager>().SomeOneInJail == 2)
            {
                Botton2.text = FindObjectOfType<GameManager>().CurrentPresoner;
            }
            if (FindObjectOfType<GameManager>().SomeOneInJail == 3)
            {
                Botton3.text = FindObjectOfType<GameManager>().CurrentPresoner;
            }
            if (FindObjectOfType<GameManager>().SomeOneInJail == 4)
            {
                Botton4.text = FindObjectOfType<GameManager>().CurrentPresoner;
            }
            if (FindObjectOfType<GameManager>().SomeOneInJail == 5)
            {
                Botton5.text = FindObjectOfType<GameManager>().CurrentPresoner;
            }
            if (FindObjectOfType<GameManager>().SomeOneInJail == 6)
            {
                Botton6.text = FindObjectOfType<GameManager>().CurrentPresoner;
            }
    }

    public void OpenCloseManu()
    {
        if (isLocalPlayer)
        {
            Click.Play();
            Manu.SetActive(!Manu.activeSelf);
        }
    }

    public void BottonOne()
    {
        Click.Play();
        CmdBottonOne();
    }
    public void BottonTow()
    {
        Click.Play();
        CmdBottonTow();
    }
    public void BottonThree()
    {
        Click.Play();
        CmdBottonThree();
    }
    public void BottonFour()
    {
        Click.Play();
        CmdBottonFour();
    }
    public void BottonFive()
    {
        Click.Play();
        CmdBottonFive();
    }
    public void BottonSix()
    {
        Click.Play();
        CmdBottonSix();
    }

    #region NetWork Comuniction
    [Command]
    void CmdBottonOne()
    {
        RpcBottonOne();
    }

    [ClientRpc]
    void RpcBottonOne()
    {
        if(FindObjectOfType<GameManager>().Money > 999 && FindObjectOfType<GameManager>().ThiefToLock > 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money - 1000;
            FindObjectOfType<GameManager>().ReleseThatPresoner = Botton1.text;
            Invoke("CmdSetReleseToNull", 2);
        }
    }

    [Command]
    void CmdBottonTow()
    {
        RpcBottonTow();
    }

    [ClientRpc]
    void RpcBottonTow()
    {
        if (FindObjectOfType<GameManager>().Money > 999 && FindObjectOfType<GameManager>().ThiefToLock > 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money - 1000;
            FindObjectOfType<GameManager>().ReleseThatPresoner = Botton2.text;
            Invoke("CmdSetReleseToNull", 2);
        }
    }

    [Command]
    void CmdBottonThree()
    {
        RpcBottonThree();
    }
    [ClientRpc]
    void RpcBottonThree()
    {
        if (FindObjectOfType<GameManager>().Money > 999 && FindObjectOfType<GameManager>().ThiefToLock > 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money - 1000;
            FindObjectOfType<GameManager>().ReleseThatPresoner = Botton3.text;
            Invoke("CmdSetReleseToNull", 2);
        }
    }

    [Command]
    void CmdBottonFour()
    {
        RpcBottonFour();
    }
    [ClientRpc]
    void RpcBottonFour()
    {
        if (FindObjectOfType<GameManager>().Money > 999 && FindObjectOfType<GameManager>().ThiefToLock > 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money - 1000;
            FindObjectOfType<GameManager>().ReleseThatPresoner = Botton4.text;
            Invoke("CmdSetReleseToNull", 2);
        }
    }

    [Command]
    void CmdBottonFive()
    {
        RpcBottonFive();
    }
    [ClientRpc]
    void RpcBottonFive()
    {
        if (FindObjectOfType<GameManager>().Money > 999 && FindObjectOfType<GameManager>().ThiefToLock > 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money - 1000;
            FindObjectOfType<GameManager>().ReleseThatPresoner = Botton5.text;
            Invoke("CmdSetReleseToNull", 2);
        }
    }

    [Command]
    void CmdBottonSix()
    {
        RpcBottonSix();
    }
    [ClientRpc]
    void RpcBottonSix()
    {
        if (FindObjectOfType<GameManager>().Money > 999 && FindObjectOfType<GameManager>().ThiefToLock > 0)
        {
            FindObjectOfType<GameManager>().Money = FindObjectOfType<GameManager>().Money - 1000;
            FindObjectOfType<GameManager>().ReleseThatPresoner = Botton6.text;
            Invoke("CmdSetReleseToNull", 2);
        };
    }


    [Command]
    void CmdSetReleseToNull()
    {
        RpcSetReleseToNull();
    }
    [ClientRpc]
    void RpcSetReleseToNull()
    {
        FindObjectOfType<GameManager>().ReleseThatPresoner = null;
    }

    [Command]
    void CmdCopUp()
    {
        FindObjectOfType<GameManager>().CopsNumber = FindObjectOfType<GameManager>().CopsNumber - 1;
    }
    [ClientRpc]
    void RpcCopUp()
    {
        FindObjectOfType<GameManager>().CopsNumber = FindObjectOfType<GameManager>().CopsNumber - 1;
    }

    [Command]
    void CmdThiefUp()
    {
        RpcThiefUp();
    }
    [ClientRpc]
    void RpcThiefUp()
    {
        FindObjectOfType<GameManager>().ThiefNumber = FindObjectOfType<GameManager>().ThiefNumber - 1;
    }
    #endregion
}

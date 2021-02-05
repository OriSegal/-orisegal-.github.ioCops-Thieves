using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] ComponentsToDisable;
    Camera SceneCamera;
    [SerializeField]
    GameObject SetupCanvas;
    private bool Cop;
    private bool Thief;
    public Text DisplayName;
    public GameObject InputField;
    [SyncVar]
    public string Pname = "Player";
    public AudioSource Click;


    void Start()
    {        
        StartCoroutine(dealiy());
    }


    void Update()
    {
        DisplayName.text = Pname;
        if (FindObjectOfType<GameManager>().TimeTostart < 1)
        {
            if (isLocalPlayer)
            {
                if (Cop == true)
                {
                    GetComponent<CopScripte>().enabled = true;
                }
                else if(Thief == true) 
                {
                    GetComponent<ThiefScripte>().enabled = true;
                }
            }
        }
    }

    public void Ready()
    {      
        Click.Play();
        CmdPlayerReady();
        if (isLocalPlayer)
        {
            Pname = InputField.GetComponent<Text>().text;
            CmdChangeName(Pname);
            SetupCanvas.SetActive(false);

            if (FindObjectOfType<GameManager>().CopsNumber != FindObjectOfType<GameManager>().ThiefNumber)
            {
                Cop = true;
                CmdCopUp();
            }
            else
            {
                Thief = true;
                CmdThiefUp();
            }

        }
    }

     void OnDisable()
     {
        if (SceneCamera != null)
        {
           SceneCamera.gameObject.SetActive(true);
        }
     }

    IEnumerator dealiy()
    {
        yield return new WaitForSeconds(2);
        if (!isLocalPlayer)
        {
            for (int i = 0; i < ComponentsToDisable.Length; i++)
            {
                ComponentsToDisable[i].enabled = false;
            }
        }
        else
        {
            CmdAllPlayers();
            SceneCamera = Camera.main;
            SetupCanvas.SetActive(true);
            if (SceneCamera != null)
            {
                SceneCamera.gameObject.SetActive(false);
            }
        }
    }

    [Command]
    void CmdCopUp()
    {
        RpcCopUp();
    }
    [ClientRpc]
    void RpcCopUp()
    {
        FindObjectOfType<GameManager>().CopsNumber = FindObjectOfType<GameManager>().CopsNumber + 1;
    }

    [Command]
    void CmdThiefUp()
    {
        RpcThiefUp();
    }
    [ClientRpc]
    void RpcThiefUp()
    {
        FindObjectOfType<GameManager>().ThiefNumber = FindObjectOfType<GameManager>().ThiefNumber + 1;
    }
    [Command]
    public void CmdPlayerReady()
    {
        RpcPlayerReady();
    }
    [ClientRpc]
    void RpcPlayerReady()
    {
        FindObjectOfType<GameManager>().PlayersRaedy++;
    }

    [Command]
    void CmdAllPlayers()
    {
        RpcAllPlayers();
    }
    [ClientRpc]
    void RpcAllPlayers()
    {
        FindObjectOfType<GameManager>().AllPlayers = FindObjectOfType<GameManager>().AllPlayers + 1;
    }

    [Command]
    public void CmdChangeName(string newName)
    {
        Pname = newName;
        if(Pname == "")
        {
            Pname = "Player";
        }

    }
}

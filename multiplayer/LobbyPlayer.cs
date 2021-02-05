using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyPlayer : NetworkLobbyPlayer
{
    
    

    void Start()
    {
        GameObject PhoneHolder = GameObject.FindGameObjectWithTag("PhoneHolder");
        transform.SetParent(PhoneHolder.transform);
        if (this.isLocalPlayer)
        {
            this.SendReadyToBeginMessage();
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    public override void OnClientEnterLobby()
    {
        base.OnClientEnterLobby();
        
    }

}

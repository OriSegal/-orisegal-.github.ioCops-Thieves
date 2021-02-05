using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class JoinTheGame: MonoBehaviour
{
    
    MatchInfoSnapshot match;
    public Text HostGame;

    LobbyManager lobbymanager;
    GameObject WaitingRoom;

    void Start()
    {
        lobbymanager = GameObject.FindGameObjectWithTag("LobbyManager").GetComponent<LobbyManager>();
        WaitingRoom = GameObject.FindGameObjectWithTag("WaitingRoom");

    }

    public void Setup(MatchInfoSnapshot _match)
    {

        match = _match;
        HostGame.text = match.name + "(" + match.currentSize + "/" + match.maxSize + ")";
    }

    public void Join()
    {
        if (lobbymanager == null)
        {
            lobbymanager = GameObject.FindGameObjectWithTag("LobbyManager").GetComponent<LobbyManager>();
        }
        var go = WaitingRoom.GetComponentsInChildren<Transform>(true);
        foreach(var item in go)
        {
            item.gameObject.SetActive(true);
        }
        lobbymanager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, lobbymanager.OnMatchJoined);
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class RefreshList : MonoBehaviour
{
    List<GameObject> roomList = new List<GameObject>();
    LobbyManager lobbymanager;

    public GameObject NewRoomListItem;
    public GameObject ViweScrollContent;

    [SerializeField]
    private Text Status;

    public AudioSource Click;


    void Start()
    {
        lobbymanager = GameObject.FindGameObjectWithTag("LobbyManager").GetComponent<LobbyManager>();
    }

    public void OnRefreshList()
    {
        Click.Play();
        ClearRoomList();
        if (lobbymanager == null)
        {
            lobbymanager = GameObject.FindGameObjectWithTag("LobbyManager").GetComponent<LobbyManager>();
        }

        if (lobbymanager.matchMaker == null)
        {
            lobbymanager.StartMatchMaker();
        }
        lobbymanager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
        Status.text = "Loading...";
    }

    private void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        Status.text = "";
        if (!success)
        {
            Status.text = "Room dose not exist";
        }

        foreach (MatchInfoSnapshot match in matchList)
        {
            GameObject NewRoomItem = Instantiate(NewRoomListItem);
            NewRoomItem.transform.SetParent(ViweScrollContent.transform);
            JoinTheGame jointhegame = NewRoomItem.GetComponent<JoinTheGame>();
            jointhegame.Setup(match);

            roomList.Add(NewRoomItem);

        }

        if (roomList.Count == 0)
        {
            Status.text = "Room dose not exist";
        }
    }

    public void ClearRoomList()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
        }

        roomList.Clear();
    }
}

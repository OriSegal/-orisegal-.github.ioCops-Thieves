using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.Match;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : NetworkBehaviour
{
    private bool Count = true;

    [SyncVar]
    public int CopsNumber;
    [SyncVar]
    public int ThiefNumber;
    [SyncVar]
    public int Money;
    [SyncVar]
    public int SomeOneInJail;
    [SyncVar]
    public string CurrentPresoner;
    [SyncVar]
    public string ReleseThatPresoner;
    [SyncVar]
    public int PlayersRaedy;
    [SyncVar]
    public int ThiefToLock;
    [SyncVar]
    public int TimeTostart = 7;
    [SyncVar]
    public int AllPlayers;


    public Text Time;

    public GameObject ThiefsWon;
    public GameObject CopsWon;

    private NetworkManager networkmanager;


    void Start()
    {
        networkmanager = NetworkManager.singleton;
        Advertisement.Initialize("3938179", false);
    }

    void LateUpdate()
    {
        if (Money >= 10000)
        {
            ThiefsWon.SetActive(true);
            StartCoroutine(BeforeExit());
            ThiefToLock = 0;
        }

        if(ThiefToLock == ThiefNumber && PlayersRaedy >= 2 && ThiefNumber != 0)
        {
            CopsWon.SetActive(true);
            StartCoroutine(BeforeExit());
        }

        if(TimeTostart > 3)
        {
            Time.text = "Not All Players ready";
        }

        if (TimeTostart <= 3 && TimeTostart > 0)
        {
            Time.text = "Starting In..." + TimeTostart;
        }
        else if(TimeTostart == 0)
        {
            Time.text = "";
        }

        if(Count == true && TimeTostart != 0)
        {
            StartCoroutine(CuontToStart());
        }
    }

    public void OnLeaveGame()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
         MatchInfo matchInfo = networkmanager.matchInfo;
         networkmanager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkmanager.OnDropConnection);
         networkmanager.StopHost();
           
    }

    IEnumerator BeforeExit()
    {
        yield return new WaitForSeconds(5);
        OnLeaveGame();
        Debug.Log("Leave Game");

    }

    IEnumerator CuontToStart()
    {
        Count = false;
       if(AllPlayers == PlayersRaedy)
        {
            yield return new WaitForSeconds(1);
            TimeTostart--;
        }

        Count = true;
    }
}

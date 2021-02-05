using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    public float PlayersNumber = 4;
    public InputField MatchNameInput;
    public LobbyManager lobbymanager;
    RefreshList refresh;

    public AudioSource Click;

    public Text DisplayNumberOfPlayers;
    public GameObject Loading;

    void Start()
    {
        if(PlayersNumber != 4)
        {
            PlayersNumber = 4;
        }
    }

    public void OnClickHostButton()
    {
        if(PlayersNumber == 2)
        {
            
            Click.Play();
            lobbymanager.maxPlayers = 2;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text,(uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
        if (PlayersNumber == 3)
        {
            
            Click.Play();
            lobbymanager.maxPlayers = 3;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
        if (PlayersNumber == 4)
        {
            Click.Play();
            lobbymanager.maxPlayers = 4;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
        if (PlayersNumber == 5)
        {
            Click.Play();
            lobbymanager.maxPlayers = 5;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
        if (PlayersNumber == 6)
        {
            Click.Play();
            lobbymanager.maxPlayers = 6;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
        if (PlayersNumber == 7)
        {
            Click.Play();
            lobbymanager.maxPlayers = 7;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
        if (PlayersNumber == 8)
        {
            Click.Play();
            lobbymanager.maxPlayers = 8;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
        if (PlayersNumber == 9)
        {
            Click.Play();
            lobbymanager.maxPlayers = 9;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
        if (PlayersNumber == 10)
        {
            Click.Play();
            lobbymanager.maxPlayers = 10;
            lobbymanager.StartMatchMaker();
            lobbymanager.matchMaker.CreateMatch(MatchNameInput.text, (uint)lobbymanager.maxPlayers, true, "", "", "", 0, 0, lobbymanager.OnMatchCreate);
            lobbymanager.minPlayers = lobbymanager.maxPlayers;
        }
    }

    public void SetPlayerNumber(float NPN)
    {
        PlayersNumber = NPN;
        DisplayNumberOfPlayers.text = PlayersNumber.ToString();
    }

}

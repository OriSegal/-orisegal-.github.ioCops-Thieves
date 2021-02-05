using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : NetworkLobbyManager
{
    public GameObject WaitingRoom;
    public GameObject MainMenu;
    public GameObject JoinRoom;
    public GameObject HostRoom;
    public GameObject JoinButton;
    public GameObject HostButton;
    public GameObject HowButton;
    public GameObject HowToPlay;
    public GameObject SinglePlay;
    public GameObject SingleButton;


    LobbyManager lobbymanager;
  

    void Start()
    {
        WaitingRoom.SetActive(false);

    }

    public override void OnStartHost()
    {
        base.OnStartHost();
        print("game created");
        WaitingRoom.SetActive(true);

    }


    void LateUpdate()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            
            MainMenu.SetActive(true);
        }
        else if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            MainMenu.SetActive(false);
            WaitingRoom.SetActive(false);
            HostRoom.SetActive(false);
            JoinRoom.SetActive(false);
            JoinButton.SetActive(true);
            HostButton.SetActive(true);
            HowButton.SetActive(true);
            HowToPlay.SetActive(false);
            SinglePlay.SetActive(false);
            SingleButton.SetActive(true);
        }
    }

    public override void OnDropConnection(bool success, string extendedInfo)
    {
        base.OnDropConnection(success, extendedInfo);
        if (success && extendedInfo == "Thief") 
        {
            FindObjectOfType<GameManager>().ThiefNumber--;
        }

        if(success && extendedInfo == "Cop")
        {
            FindObjectOfType<GameManager>().CopsNumber--;
        }
    }

    public void ExitLobby()
    {
        
    }

}

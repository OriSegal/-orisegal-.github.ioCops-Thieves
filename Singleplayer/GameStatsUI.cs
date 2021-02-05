using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatsUI : MonoBehaviour
{
    public Text MoneyStats;
    public Text Prisoners;
    public GameObject Panel;

    void Start()
    {
        
    }


    void Update()
    {
        MoneyStats.text = FindObjectOfType<SingleGameManager>().MoneyCollected.ToString() + " / " + FindObjectOfType<SingleGameManager>().MoneyToCollect.ToString();
        Prisoners.text = FindObjectOfType<SingleGameManager>().ThievesInJail.ToString() + " / " + FindObjectOfType<SingleGameManager>().CurrentNumberOfThieves.ToString();
    }

    public void OpenClosePanrl()
    {
        Panel.SetActive(!Panel.activeSelf);
    }

    public void ToLobby()
    {
        SceneManager.LoadScene(0);
    }
}

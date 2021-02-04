using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class SingleGameManager : MonoBehaviour,IUnityAdsListener
{
    private int SceneNumber;
    public int MoneyToCollect;
    public int MoneyCollected;
    public int CurrentNumberOfThieves;
    public int ThievesInJail;
    [SerializeField]
    private bool CopPlayer;
    [SerializeField]
    private bool ThiefPlayer;
    private bool Reward = false;

    public GameObject WatchForLives;
    public GameObject GoldEffect;
    public GameObject CopWon;
    public GameObject ThievesWon;
    public GameObject WininSound;

    public GameObject instructions01;
    public GameObject instructions02;
    public GameObject instructions03;
    public GameObject instructions04;
    public GameObject instructions05;
    public GameObject instructions06;
    public GameObject instructions10;

    string placement = "rewardedVideo";



    void Start()
    {
        SetUpAds();
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
        GameObject Cop = GameObject.FindGameObjectWithTag("Cop");
        GameObject Thief = GameObject.FindGameObjectWithTag("Thief");
        if(Cop != null)
        {
            CopPlayer = true;
            ThiefPlayer = false;
        }

        if(Thief != null)
        {
            ThiefPlayer = true;
            CopPlayer = false;
        }
        Instructions();
    }


    void Update()
    {
        if(CurrentNumberOfThieves == ThievesInJail && CopPlayer == true)
        {
            FindObjectOfType<DataShop>().UnlockNewLevel01();
            FindObjectOfType<DataShop>().UnlockNewLevel02();
            FindObjectOfType<DataShop>().UnlockNewLevel03();
            FindObjectOfType<DataShop>().UnlockNewLevel04();
            FindObjectOfType<DataShop>().UnlockNewLevel05();
            FindObjectOfType<DataShop>().UnlockNewLevel06();
            FindObjectOfType<DataShop>().UnlockNewLevel07();
            FindObjectOfType<DataShop>().UnlockNewLevel08();
            FindObjectOfType<DataShop>().UnlockNewLevel09();
            CopWon.SetActive(true);
            GoldEffect.SetActive(true);
            WininSound.SetActive(true);
            StartCoroutine(BaclToLobby());
            FindObjectOfType<DataShop>().LoserGoldAmunt();
            CopPlayer = false;
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
            }
        }

        if(MoneyCollected >= MoneyToCollect && ThiefPlayer == true)
        {
            FindObjectOfType<DataShop>().UnlockNewLevel01();
            FindObjectOfType<DataShop>().UnlockNewLevel02();
            FindObjectOfType<DataShop>().UnlockNewLevel03();
            FindObjectOfType<DataShop>().UnlockNewLevel04();
            FindObjectOfType<DataShop>().UnlockNewLevel05();
            FindObjectOfType<DataShop>().UnlockNewLevel06();
            FindObjectOfType<DataShop>().UnlockNewLevel07();
            FindObjectOfType<DataShop>().UnlockNewLevel08();
            FindObjectOfType<DataShop>().UnlockNewLevel09();
            ThievesWon.SetActive(true);
            GoldEffect.SetActive(true);
            WininSound.SetActive(true);
            StartCoroutine(BaclToLobby());
            FindObjectOfType<DataShop>().LoserGoldAmunt();
            ThiefPlayer = false;
            if(SceneManager.GetActiveScene().buildIndex == 11)
            {
                if (Advertisement.IsReady())
                {
                    FindObjectOfType<DataShop>().LoserGoldAmunt();
                    FindObjectOfType<DataShop>().LoserGoldAmunt();
                    Advertisement.Show();
                }
            }
        }

        if (CurrentNumberOfThieves == ThievesInJail && ThiefPlayer == true)
        {
            ThiefPlayer = false;
            if(FindObjectOfType<LifeSystem>().lives > 0)
            {
                FindObjectOfType<LifeSystem>().lives--;
                CopWon.SetActive(true);
                if (FindObjectOfType<LifeSystem>().lives < 1)
                {
                    WatchForLives.SetActive(true);
                    CopWon.SetActive(false);
                    return;
                }
                StartCoroutine(BaclToLobby());
            }
        }

        if (MoneyCollected >= MoneyToCollect && CopPlayer == true)
        {           
            CopPlayer = false;
            if (FindObjectOfType<LifeSystem>().lives > 0)
            {
                FindObjectOfType<LifeSystem>().lives--;
                ThievesWon.SetActive(true);
                if (FindObjectOfType<LifeSystem>().lives < 1)
                {
                    WatchForLives.SetActive(true);
                    ThievesWon.SetActive(false);
                    return;
                }
                StartCoroutine(BaclToLobby());
            }

        }
    }

    IEnumerator BaclToLobby()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
        
    }

    void Instructions()
    {
        switch (SceneNumber)
        {
            case 2: instructions01.SetActive(true);
                Time.timeScale = 0;
                break;
            case 3: instructions02.SetActive(true);
                Time.timeScale = 0;
                break;
            case 4:
                instructions03.SetActive(true);
                Time.timeScale = 0;
                break;
            case 5:
                instructions04.SetActive(true);
                Time.timeScale = 0;
                break;
            case 6:
                instructions05.SetActive(true);
                Time.timeScale = 0;
                break;
            case 7:
                instructions06.SetActive(true);
                Time.timeScale = 0;
                break;
            case 11:
                instructions10.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }

    public void Countinue()
    {
        Time.timeScale = 1;
        switch (SceneNumber)
        {
            case 2:
                instructions01.SetActive(false);
                break;
            case 3: instructions02.SetActive(false);
                break;
            case 4:
                instructions03.SetActive(false);
                break;
            case 5:
                instructions04.SetActive(false);
                break;
            case 6:
                instructions05.SetActive(false);
                break;
            case 7:
                instructions06.SetActive(false);
                break;
            case 11:
                instructions10.SetActive(false);
                break;
        }
    }

    public void ShowAds()
    {
        if (Advertisement.IsReady(placement))
        {
            Advertisement.Show(placement);
            Reward = true;
        }
    }

    void SetUpAds()
    {
        Advertisement.Initialize("3938179", false);
        Advertisement.AddListener(this);
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished && Reward == true)
        {
            FindObjectOfType<LifeSystem>().GainLife();
            SceneManager.LoadScene(0);
            Reward = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class DataShop : MonoBehaviour,IUnityAdsListener
{
    private static DataShop instance;
    public static DataShop Instance { get { return instance; } }

    public int UnlockLevels = 0;

    public int UserGold = 0;
    public int UserSkin = 0;
    public int UserSkinThiefs = 0;

    public int C01 = 0;
    public int C02 = 0;
    public int T01 = 0;
    public int T02 = 0;

    public Text FreeReword;
    public Text GoldText;
    public Text C01Button;
    public Text C02Button;
    public Text T01Button;
    public Text T02Button;
    public GameObject C01Gold;
    public GameObject C02Gold;
    public GameObject T01Gold;
    public GameObject T02Gold;
    public GameObject NotGold;

    public AudioSource Buy;
    public AudioSource Clik;

    public GameObject ShopButton;
    public GameObject Canvas;

    string placement = "rewardedVideo";

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        SetUpAds();
        if (PlayerPrefs.HasKey("Levels"))
        {
            UnlockLevels = PlayerPrefs.GetInt("Levels");
        }
        else
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels);
        }

        if (PlayerPrefs.HasKey("Levels"))
        {
            UnlockLevels = PlayerPrefs.GetInt("Levels");
        }
        else
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels);
        }
        

        if (PlayerPrefs.HasKey("Gold"))
        {
            UserGold = PlayerPrefs.GetInt("Gold");
        }
        else
        {
            PlayerPrefs.SetInt("Gold", UserGold);
        }

        if (PlayerPrefs.HasKey("ThiefSkins"))
        {
            UserSkinThiefs = PlayerPrefs.GetInt("ThiefSkins");
        }
        else
        {
            PlayerPrefs.SetInt("ThiefSkins", UserSkinThiefs);
        }

        if (PlayerPrefs.HasKey("Skins"))
        {
            UserSkin = PlayerPrefs.GetInt("Skins");
        }
        else
        {
            PlayerPrefs.SetInt("Skins", UserSkin);
        }

        if (PlayerPrefs.HasKey("C01"))
        {
            C01 = PlayerPrefs.GetInt("C01");
        }
        else
        {
            PlayerPrefs.SetInt("C01", C01);
        }

        if (PlayerPrefs.HasKey("C02"))
        {
            C02 = PlayerPrefs.GetInt("C02");
        }
        else
        {
            PlayerPrefs.SetInt("C02", C02);
        }

        if (PlayerPrefs.HasKey("T01"))
        {
            T01 = PlayerPrefs.GetInt("T01");
        }
        else
        {
            PlayerPrefs.SetInt("T01", T01);
        }

        if (PlayerPrefs.HasKey("T02"))
        {
            T02 = PlayerPrefs.GetInt("T02");
        }
        else
        {
            PlayerPrefs.SetInt("T02", T02);
        }
    }

    public void GoTOShop()
    {
        Clik.Play();
        Canvas.SetActive(true);
        CloseShopButton();
    }

    public void CloseShop()
    {
        Clik.Play();
        Canvas.SetActive(false);
        OpenShopButton();
    }



    public void UseCopSkin00()
    {
        Clik.Play();
        PlayerPrefs.SetInt("Skins", UserSkin = 0);
        UserSkin = PlayerPrefs.GetInt("Skins");
    }

    public void UseThiefSkin00()
    {
        Clik.Play();
        PlayerPrefs.SetInt("ThiefSkins", UserSkinThiefs = 0);
        UserSkinThiefs = PlayerPrefs.GetInt("ThiefSkins");
    }

    public void BuyUseCopSkin01()
    {
        if(C01 == 0 && UserGold > 24)
        {
            Buy.Play();
            PlayerPrefs.SetInt("Skins", UserSkin = 1);
            PlayerPrefs.SetInt("C01", C01 = 1);
            PlayerPrefs.SetInt("Gold", UserGold = UserGold - 25);
        }
        else if(C01 == 0 && UserGold < 25)
        {
            NotGold.SetActive(true);
        }


        if(C01 == 1)
        {
            Clik.Play();
            PlayerPrefs.SetInt("Skins", UserSkin = 1);
            UserSkin = PlayerPrefs.GetInt("Skins");
        }
    }

    public void BuyUseThiefSkin1()
    {
        if (T01 == 0 && UserGold > 24)
        {
            Buy.Play();
            PlayerPrefs.SetInt("ThiefSkins", UserSkinThiefs = 1);
            PlayerPrefs.SetInt("T01", T01 = 1);
            PlayerPrefs.SetInt("Gold", UserGold = UserGold - 25);
        }
        else if(T01 == 0 && UserGold < 25)
        {
            NotGold.SetActive(true);
        }


        if (T01 == 1)
        {
            Clik.Play();
            PlayerPrefs.SetInt("ThiefSkins", UserSkinThiefs = 1);
            UserSkinThiefs = PlayerPrefs.GetInt("ThiefSkins");
        }
    }

    public void BuyUseCopSkin02()
    {
        if (C02 == 0 && UserGold > 49)
        {
            Buy.Play();
            PlayerPrefs.SetInt("Skins", UserSkin = 2);
            PlayerPrefs.SetInt("C02", C02 = 1);
            PlayerPrefs.SetInt("Gold", UserGold = UserGold - 50);
        }
        else if(C02 == 0 && UserGold < 50)
        {
            NotGold.SetActive(true);
        }


        if (C02 == 1)
        {
            Clik.Play();
            PlayerPrefs.SetInt("Skins", UserSkin = 2);
            UserSkin = PlayerPrefs.GetInt("Skins");
        }
    }

    public void BuyUseCThiefSkin02()
    {
        if (T02 == 0 && UserGold > 49)
        {
            Buy.Play();
            PlayerPrefs.SetInt("ThiefSkins", UserSkinThiefs = 2);
            PlayerPrefs.SetInt("T02", T02 = 1);
            PlayerPrefs.SetInt("Gold", UserGold = UserGold - 50);
        }
        else if(T02 == 0 && UserGold < 50)
        {
            NotGold.SetActive(true);
        }


        if (T02 == 1)
        {
            Clik.Play();
            PlayerPrefs.SetInt("ThiefSkins", UserSkinThiefs = 2);
            UserSkinThiefs = PlayerPrefs.GetInt("ThiefSkins");
        }
    }


    public void LoserGoldAmunt()
    {
        PlayerPrefs.SetInt("Gold", UserGold = UserGold + 2);
    }

    public void WinerGoldAmunt()
    {
        PlayerPrefs.SetInt("Gold", UserGold = UserGold + 4);
    }

    public void AdsAmunt()
    {
        PlayerPrefs.SetInt("Gold", UserGold = UserGold + 2);
    }

    void Update()
    {
        GoldText.text = UserGold.ToString();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ShopButton.SetActive(true);
            if (C01 == 0)
            {
                C01Button.text = "Buy";
            }
            else if (C01 == 1)
            {
                C01Gold.SetActive(false);
                C01Button.text = "Use";
            }

            if (C02 == 0)
            {
                
                C02Button.text = "Buy";
            }
            else if (C02 == 1)
            {
                C02Gold.SetActive(false);
                C02Button.text = "Use";
            }

            if (T01 == 0)
            {
                T01Button.text = "Buy";
            }
            else if (T01 == 1)
            {
                T01Gold.SetActive(false);
                T01Button.text = "Use";
            }

            if(T02 == 0)
            {
                T02Button.text = "Buy";
            }
            else if(T02 == 1)
            {
                T02Gold.SetActive(false);
                T02Button.text = "Use";
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            ShopButton.SetActive(false);
            Canvas.SetActive(false);
        }
    }

    public void CloseShopButton()
    {
        ShopButton.SetActive(false);
    }

    public void OpenShopButton()
    {
        ShopButton.SetActive(true);
    }

    public void OnUnityAdsReady(string placementId)
    {
        FreeReword.text = "Get your free reward";
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished && Canvas.activeSelf)
        {
            AdsAmunt();
        }
    }

    public void WatchAd()
    {
        Clik.Play();
        if (Advertisement.IsReady(placement))
        {
            Advertisement.Show(placement);
        }
    }

    void SetUpAds()
    {
        Advertisement.Initialize("3938179", false);
        Advertisement.AddListener(this);
    }

    public void UnlockNewLevel01()
    {
        if (UnlockLevels == 0 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 1);
        }
    }

    public void UnlockNewLevel02()
    {
        if (UnlockLevels == 1 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 2);
        }
    }

    public void UnlockNewLevel03()
    {
        if (UnlockLevels == 2 && SceneManager.GetActiveScene().buildIndex == 4)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 3);
        }
    }

    public void UnlockNewLevel04()
    {
        if (UnlockLevels == 3 && SceneManager.GetActiveScene().buildIndex == 5)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 4);
        }
    }

    public void UnlockNewLevel05()
    {
        if (UnlockLevels == 4 && SceneManager.GetActiveScene().buildIndex == 6)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 5);
        }
    }

    public void UnlockNewLevel06()
    {
        if (UnlockLevels == 5 && SceneManager.GetActiveScene().buildIndex == 7)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 6);
        }
    }

    public void UnlockNewLevel07()
    {
        if (UnlockLevels == 6 && SceneManager.GetActiveScene().buildIndex == 8)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 7);
        }
    }

    public void UnlockNewLevel08()
    {
        if (UnlockLevels == 7 && SceneManager.GetActiveScene().buildIndex == 9)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 8);
        }
    }

    public void UnlockNewLevel09()
    {
        if (UnlockLevels == 8 && SceneManager.GetActiveScene().buildIndex == 10)
        {
            PlayerPrefs.SetInt("Levels", UnlockLevels = 9);
        }
    }

}

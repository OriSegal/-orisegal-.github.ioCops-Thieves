using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopPlayerAnim : MonoBehaviour
{
    private Animator Anim;
    private CopPlayer copPlayer;
    private float moneH;
    public GameObject FootSteps;

    void Start()
    {
        Anim = GetComponent<Animator>();
        copPlayer = GetComponent<CopPlayer>();
        ChoseStartAnim();
    }


    void Update()
    {
        moneH = copPlayer.MoveH;
        CopSkin00();
        CopSkin01();
        CopSkin02();
    }

    void ChoseStartAnim()
    {
        if (FindObjectOfType<DataShop>().UserSkin == 0)
        {
            Anim.Play("C00S");
        }

        if (FindObjectOfType<DataShop>().UserSkin == 1)
        {
            Anim.Play("C01S");
        }

        if (FindObjectOfType<DataShop>().UserSkin == 2)
        {
            Anim.Play("C02S");
        }

    }

    void CopSkin00()
    {
        if (FindObjectOfType<DataShop>().UserSkin == 0)
        {
            if (moneH > 0)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C00R", true);
                Anim.SetBool("C00L", false);
                Anim.SetBool("C00S", false);
            }
            else if (moneH < 0)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C00L", true);
                Anim.SetBool("C00R", false);
                Anim.SetBool("C00S", false);
            }
            if (moneH == 0)
            {
                FootSteps.SetActive(false);
                Anim.SetBool("C00S", true);
                Anim.SetBool("C00R", false);
                Anim.SetBool("C00L", false);

            }
        }
    }

    void CopSkin01()
    {
        if (FindObjectOfType<DataShop>().UserSkin == 1)
        {
            if (moneH > 0)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C01R", true);
                Anim.SetBool("C01L", false);
                Anim.SetBool("C01S", false);
            }
            else if (moneH < 0)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C01L", true);
                Anim.SetBool("C01R", false);
                Anim.SetBool("C01S", false);
            }
            if (moneH == 0)
            {
                FootSteps.SetActive(false);
                Anim.SetBool("C01S", true);
                Anim.SetBool("C01R", false);
                Anim.SetBool("C01L", false);

            }
        }
    }

    void CopSkin02()
    {
        if (FindObjectOfType<DataShop>().UserSkin == 2)
        {
            if (moneH > 0)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C02R", true);
                Anim.SetBool("C02L", false);
                Anim.SetBool("C02S", false);
            }
            else if (moneH < 0)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C02L", true);
                Anim.SetBool("C02R", false);
                Anim.SetBool("C02S", false);
            }
            if (moneH == 0)
            {
                FootSteps.SetActive(false);
                Anim.SetBool("C02S", true);
                Anim.SetBool("C02R", false);
                Anim.SetBool("C02L", false);

            }
        }
    }
}

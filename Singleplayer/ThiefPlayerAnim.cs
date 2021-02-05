using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefPlayerAnim : MonoBehaviour
{

    private Animator Anim;
    private ThiefPlayer thiefPlayer;
    private float moveH;
    public GameObject FootSteps;


    void Start()
    {
        Anim = GetComponent<Animator>();
        thiefPlayer = GetComponent<ThiefPlayer>();
        ChoseStratAnim();
    }


    void Update()
    {
        moveH = thiefPlayer.MoveH;
        ThiefSkin00();
        ThiefSkin01();
        ThiefSkin02();
    }

    void ChoseStratAnim()
    {
        if (FindObjectOfType<DataShop>().UserSkinThiefs == 0)
        {
            Anim.Play("T00S");
        }

        if (FindObjectOfType<DataShop>().UserSkinThiefs == 1)
        {
            Anim.Play("T01S");
        }

        if (FindObjectOfType<DataShop>().UserSkinThiefs == 2)
        {
            Anim.Play("T02S");
        }

    }

    void ThiefSkin00()
    {
        if (moveH > 0)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T00R", true);
            Anim.SetBool("T00L", false);
            Anim.SetBool("T00S", false);
        }
        else if (moveH < 0)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T00L", true);
            Anim.SetBool("T00R", false);
            Anim.SetBool("T00S", false);
        }
        if (moveH == 0)
        {
            FootSteps.SetActive(false);
            Anim.SetBool("T00S", true);
            Anim.SetBool("T00R", false);
            Anim.SetBool("T00L", false);
        }
    }

    void ThiefSkin01()
    {
        if (moveH > 0)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T01R", true);
            Anim.SetBool("T01L", false);
            Anim.SetBool("T01S", false);
        }
        else if (moveH < 0)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T01L", true);
            Anim.SetBool("T01R", false);
            Anim.SetBool("T01S", false);
        }
        if (moveH == 0)
        {
            FootSteps.SetActive(false);
            Anim.SetBool("T01S", true);
            Anim.SetBool("T01R", false);
            Anim.SetBool("T01L", false);
        }
    }

    void ThiefSkin02()
    {
        if (moveH > 0)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T02R", true);
            Anim.SetBool("T02L", false);
            Anim.SetBool("T02S", false);
        }
        else if (moveH < 0)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T02L", true);
            Anim.SetBool("T02R", false);
            Anim.SetBool("T02S", false);
        }
        if (moveH == 0)
        {
            FootSteps.SetActive(false);
            Anim.SetBool("T02S", true);
            Anim.SetBool("T02R", false);
            Anim.SetBool("T02L", false);
        }
    }
}

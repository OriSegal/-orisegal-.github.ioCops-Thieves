using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadCangerThief : MonoBehaviour
{
    private Image MyImage;
    public Sprite ThiefHead00;
    public Sprite ThiefHead01;
    public Sprite ThiefHead02;


    void Start()
    {
        MyImage = GetComponent<Image>();
    }

    void Update()
    {
        if (FindObjectOfType<DataShop>().UserSkinThiefs == 0)
        {
            MyImage.rectTransform.sizeDelta = new Vector2(230, 290);
            MyImage.sprite = ThiefHead00;
        }
        if (FindObjectOfType<DataShop>().UserSkinThiefs == 1)
        {
            MyImage.rectTransform.sizeDelta = new Vector2(265, 275);
            MyImage.sprite = ThiefHead01;
        }
        if (FindObjectOfType<DataShop>().UserSkinThiefs == 2)
        {
            MyImage.rectTransform.sizeDelta = new Vector2(260, 305);
            MyImage.sprite = ThiefHead02;
        }

    }
}

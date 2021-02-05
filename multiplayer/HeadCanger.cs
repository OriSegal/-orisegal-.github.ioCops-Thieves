using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadCanger : MonoBehaviour
{
    private Image MyImage;
    public Sprite CopHead00;
    public Sprite CopHead01;
    public Sprite CopHead02;


    void Start()
    {
        MyImage = GetComponent<Image>();
    }

    void Update()
    {
        if(FindObjectOfType<DataShop>().UserSkin == 0)
        {
            MyImage.rectTransform.sizeDelta = new Vector2(235, 265);
            MyImage.sprite = CopHead00;
        }
        if (FindObjectOfType<DataShop>().UserSkin == 1)
        {
            MyImage.rectTransform.sizeDelta = new Vector2(250, 260);
            MyImage.sprite = CopHead01;
        }
        if (FindObjectOfType<DataShop>().UserSkin == 2)
        {
            MyImage.rectTransform.sizeDelta = new Vector2(250, 260);
            MyImage.sprite = CopHead02;
        }

    }
}

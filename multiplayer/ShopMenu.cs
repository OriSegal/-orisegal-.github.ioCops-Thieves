using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    private Canvas ShopCanvsd;

    void Start()
    {

    }

    public void ToShop()
    {
        ShopCanvsd.sortingOrder = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallMoneyBar : MonoBehaviour
{
    public SmallMoney money;
    public Image FillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }


    void Update()
    {
        slider.value = money.TimeToOpen;
    }
}

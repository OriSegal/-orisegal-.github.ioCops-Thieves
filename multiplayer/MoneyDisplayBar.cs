using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplayBar : MonoBehaviour
{

    public MoneyScript money;
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

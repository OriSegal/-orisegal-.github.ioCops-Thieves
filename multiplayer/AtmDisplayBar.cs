using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmDisplayBar : MonoBehaviour
{

    public Atm atm;
    public Image FillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>(); 
    }


    void Update()
    {
        slider.value = atm.TimeToOpen;
    }
}

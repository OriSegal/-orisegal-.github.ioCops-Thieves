using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MoneyDisplay : NetworkBehaviour
{
    public Text Moneydisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Moneydisplay.text = FindObjectOfType<GameManager>().Money.ToString("Collected Money: " + 0);
    }
}

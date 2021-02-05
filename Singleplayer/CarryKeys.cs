using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryKeys : MonoBehaviour
{
    public bool Key1 = false;
    public bool Key2 = false;
    public bool Key3 = false;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Key1" && Key2 == false && Key3 == false)
        {
            Invoke("KeyOne", 1);
        }

        if (collision.gameObject.name == "Key2" && Key1 == false && Key3 == false)
        {
            Invoke("KeyTow", 1);
        }

        if (collision.gameObject.name == "Key3" && Key1 == false && Key2 == false)
        {
            Invoke("KeyThree", 1);
        }
    }

    void KeyOne()
    {
        Key1 = true;
    }

    void KeyTow()
    {
        Key2 = true;
    }

    void KeyThree()
    {
        Key3 = true;
    }
}

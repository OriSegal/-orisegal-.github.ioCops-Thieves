using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "Thief")
        {
            if (FindObjectOfType<CarryKeys>().Key1 == false && FindObjectOfType<CarryKeys>().Key2 == false && FindObjectOfType<CarryKeys>().Key3 == false)
            {
                Destroy(this.gameObject);
            }
        }  
    }
}

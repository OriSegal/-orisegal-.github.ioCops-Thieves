using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupUpcloser : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Close", 2);
    }

    void Close()
    {
        this.gameObject.SetActive(false);
    }

}

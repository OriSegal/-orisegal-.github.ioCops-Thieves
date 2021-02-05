using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoserReword : MonoBehaviour
{
    void OnEnable()
    {
        FindObjectOfType<DataShop>().LoserGoldAmunt();
        Invoke("UnActive", 10);
    }

    void UnActive()
    {
        gameObject.SetActive(false);
    }
}

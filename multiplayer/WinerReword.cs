using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinerReword : MonoBehaviour
{
    void OnEnable()
    {
        FindObjectOfType<DataShop>().WinerGoldAmunt();
    }

}

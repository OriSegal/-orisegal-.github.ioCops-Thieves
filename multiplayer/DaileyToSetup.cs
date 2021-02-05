using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaileyToSetup : MonoBehaviour
{
     PlayerSetup PlayerSetUp;

    void Start()
    {
        StartCoroutine(dilaey());
        
        
    }

    IEnumerator dilaey()
    {
        yield return new WaitForSeconds(2);
        PlayerSetUp.enabled = true;
    }

}

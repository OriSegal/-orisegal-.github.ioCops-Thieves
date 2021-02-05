using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoldScript : NetworkBehaviour
{
    public GameObject GoldSound;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("DestroyGold", 0.2f);
        GoldSound.SetActive(true);
    }

    void DestroyGold()
    {
        NetworkServer.Destroy(this.gameObject);
    }

}

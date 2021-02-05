using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SThrowable : MonoBehaviour
{
    private GameObject Thief;

    void Start()
    {
        Thief = GameObject.FindGameObjectWithTag("Thief");
        Invoke("DestroyThis", 0.3f);
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Thief.transform.position, 100);
    }

    public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}

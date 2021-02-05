using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefNPCAnim : MonoBehaviour
{
    private Animator Anim;
    Vector2 lastPos;
    Vector2 currentPos;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        Anim.Play("T00S");
        lastPos = transform.position;
    }


    void Update()
    {
        currentPos = transform.position;
        if (currentPos.x > lastPos.x)
        {
            Anim.SetBool("T00R", true);
            Anim.SetBool("T00L", false);
        }
        else if (currentPos.x < lastPos.x)
        {
            Anim.SetBool("T00L", true);
            Anim.SetBool("T00R", false);
        }

        lastPos = currentPos;
    }
}

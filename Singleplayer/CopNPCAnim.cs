using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopNPCAnim : MonoBehaviour
{
    private Animator Anim;
    Vector2 lastPos;
    Vector2 currentPos;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        Anim.Play("C00S");
        lastPos = transform.position;
    }


    void Update()
    {
        currentPos = transform.position;
        if(currentPos.x > lastPos.x)
        {
            Anim.SetBool("C00R", true);
            Anim.SetBool("C00L", false);
        }
        else if(currentPos.x < lastPos.x)
        {
            Anim.SetBool("C00L", true);
            Anim.SetBool("C00R", false);
        }

        lastPos = currentPos;
    }
}

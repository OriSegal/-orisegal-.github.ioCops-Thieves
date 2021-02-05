using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiefPlayer : MonoBehaviour
{
    public Transform jail;
    public Joystick joystick;
    private Rigidbody2D rigidbody2D;
    public Slider StaminaSlider;
    public AudioSource FootStep;

    public float Speed = 9f;
    public float MoveH;
    public float MoveV;
    [SerializeField]
    private float Stamina = 100;
    private int tapCount;

    public GameObject InvisibilityBottun;
    public GameObject InvisibilityObj;
    public GameObject SlightHand;

    public bool Hit;
    public bool Slight;
    [SerializeField]
    private bool IsRuning;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Input.multiTouchEnabled = true;
    }


    void Update()
    {
        StaminaSlider.value = Stamina;
        PlayerMovement();
        DoubleTap();
        Runing();


    }

    void PlayerMovement()
    {
        MoveH = joystick.Horizontal;
        MoveV = joystick.Vertical;
        rigidbody2D.velocity = new Vector2(MoveH * Speed, MoveV * Speed);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Trhowable")
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, jail.position, 100);
        }

        if(collision.gameObject.tag == "Invisibility")
        {
            InvisibilityBottun.SetActive(true);
        }
        if(collision.gameObject.tag == "Hand")
        {
            SlightHand.SetActive(true);
        }
    }

    public void ActiveInvisibility()
    {
        Invoke("DisableInvisibility", 10);
        InvisibilityObj.SetActive(true);
        InvisibilityBottun.SetActive(false);
    }

    void DisableInvisibility()
    {
        InvisibilityObj.SetActive(false);
    }

    public void SlightOfHands()
    {
        SlightHand.SetActive(false);
        Invoke("DisableSlightOfHands", 15);
        Slight = true;
    }

    void DisableSlightOfHands()
    {
        Slight = false;
    }

    public void Portal()
    {
        GameObject Pip1 = GameObject.FindGameObjectWithTag("PipeCover1");
        GameObject Pip2 = GameObject.FindGameObjectWithTag("PipeCover2");
        GameObject Pip3 = GameObject.FindGameObjectWithTag("PipeCover3");
        GameObject Pip4 = GameObject.FindGameObjectWithTag("PipeCover4");
        GameObject Pip5 = GameObject.FindGameObjectWithTag("PipeCover5");
        GameObject Pip6 = GameObject.FindGameObjectWithTag("PipeCover6");
        GameObject Pip7 = GameObject.FindGameObjectWithTag("PipeCover7");
        GameObject Pip8 = GameObject.FindGameObjectWithTag("PipeCover8");
        GameObject Pip9 = GameObject.FindGameObjectWithTag("PipeCover9");
        GameObject Pip10 = GameObject.FindGameObjectWithTag("PipeCover10");
        if (Vector2.Distance(transform.position, Pip1.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip2.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip2.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip1.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip3.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip4.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip4.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip3.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip5.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip6.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip6.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip5.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip7.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip8.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip8.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip7.transform.position, 100 + Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, Pip9.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip10.transform.position, 100 + Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, Pip10.transform.position) < 2)
        {
            rigidbody2D.position = Vector2.MoveTowards(transform.position, Pip9.transform.position, 100 + Time.deltaTime);
        }
    }

    public void OpenMoney()
    {
        Hit = true;
        StartCoroutine(HitDealy());
        tapCount = 0;
    }

    void DoubleTap()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended || Input.touchCount > 1 && Input.GetTouch(1).phase == TouchPhase.Ended)
        {
            tapCount += 1;
            StartCoroutine(Countdown());
        }

        if (tapCount == 2)
        {
            tapCount = 0;
            StopCoroutine(Countdown());
            IsRuning = !IsRuning;
        }
    }

    void Runing()
    {
        if(Stamina <= 0 || IsRuning == false)
        {
            Speed = 8;
            FootStep.pitch = 1.2f;
        }

        if(IsRuning && Stamina > 0)
        {
            Speed = 10;
            Stamina = Stamina - 15 * Time.deltaTime;
            FootStep.pitch = 1.5f;
            if(Stamina <= 0)
            {
                IsRuning = false;
            }
        }

        if(!IsRuning && Stamina < 100)
        {
            Stamina = Stamina + 5 * Time.deltaTime;
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.3f);
        tapCount = 0;
    }

    IEnumerator HitDealy()
    {
        yield return new WaitForSeconds(0.05f);
        Hit = false;
    }
}

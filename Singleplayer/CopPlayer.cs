using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopPlayer : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody2D rigidbody2D;
    public Slider StaminaSlider;
    public AudioSource FootStep;

    public float Speed = 8f;
    public float MoveH;
    public float MoveV;
    private float Stamina = 100;
    private int tapCount;

    public GameObject PinkDountBottun;
    public GameObject BlueDountBottun;

    public GameObject BlueDonutLeft;
    public GameObject BlueDonutRight;

    public bool Chatch = false;
    [SerializeField]
    private bool IsRuning;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
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
        if(collision.gameObject.tag == "Donut")
        {
            PinkDountBottun.SetActive(true);
        }

        if (collision.gameObject.tag == "BlueDount")
        {
            BlueDountBottun.SetActive(true);
        }
    }

    public void SpwanBlueDonut()
    {
        BlueDountBottun.SetActive(false);
        if (MoveH > 0 || MoveH == 0)
        {
            Instantiate(BlueDonutRight, transform.position, Quaternion.identity);
        }
        else if(MoveH < 0)
        {
            Instantiate(BlueDonutLeft, transform.position, Quaternion.identity);
        }
    }

    public void TryToChatch()
    {
        Chatch = true;
        StartCoroutine(ChatchDealy());
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
        if (Stamina <= 0 || IsRuning == false)
        {
            Speed = 8;
            FootStep.pitch = 1.2f;
        }

        if (IsRuning && Stamina > 0)
        {
            Speed = 10;
            Stamina = Stamina - 15 * Time.deltaTime;
            FootStep.pitch = 1.5f;
            if (Stamina <= 0)
            {
                IsRuning = false;
            }
        }

        if (!IsRuning && Stamina < 100)
        {
            Stamina = Stamina + 5 * Time.deltaTime;
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.3f);
        tapCount = 0;
    }

    IEnumerator ChatchDealy()
    {
        yield return new WaitForSeconds(0.05f);
        Chatch = false;
    }

    public void PinkDountEffect()
    {
        Stamina = 100;
        PinkDountBottun.SetActive(false);
    }
}

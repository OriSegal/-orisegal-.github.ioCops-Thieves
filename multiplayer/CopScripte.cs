using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CopScripte : NetworkBehaviour
{
    private SpriteRenderer MySpriteRenderer;
    public Sprite Cop;
    private Rigidbody2D MyRigidbody;
    private Animator Anim;
    public Slider StaminaSlider;
    private Vector2 LastX;
    private Vector2 CurrentX;
    public float Speed = 7f;
    public float MoveH = 0f;
    public float MoveV = 0f;
    private int tapCount;
    [SerializeField]
    private float Stamina = 100;
    public Joystick joystick;
    public GameObject Buttom;
    public GameObject DountBotton;
    public GameObject BlueDountButton;
    public GameObject Trap;
    private bool TrapSet = true;
    [SerializeField]
    private bool IsRuning;
    public Text CopButtonText;
    public GameObject FootSteps;
    public bool Lodedd = false;

    public GameObject WinerReword;
    public GameObject LoserReword;


    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        MySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (MySpriteRenderer.sprite == null)
        {
            MySpriteRenderer.sprite = Cop;
        }
        MyRigidbody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        LastX = transform.position;
        gameObject.tag = "Cop";
        CmdImCop();
        if(gameObject.tag == "Cop")
        {
            Buttom.SetActive(false);
        }
        ChoseStartAnim();
    }

    void FixedUpdate()
    {
        StaminaSlider.value = Stamina;
        CurrentX = transform.position;
        JoystickMovement();
        Rewords();
        DoubleTap();
        Runing();
    }

    void JoystickMovement()
    {
        MoveH = joystick.Horizontal;
        MoveV = joystick.Vertical;
        MyRigidbody.velocity = new Vector2(MoveH * Speed, MoveV * Speed);
        CopSkin00();
        CopSkin01();
        CopSkin02();
        LastX = transform.position;

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
            Speed = 8f;
            //FootStep.pitch = 1.2f;
        }

        if (IsRuning && Stamina > 0)
        {
            Speed = 10f;
            Stamina = Stamina - 15 * Time.deltaTime;
            //FootStep.pitch = 1.5f;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Donut" && GetComponent<CopScripte>().enabled == true)
        {
            DountBotton.SetActive(true);     
        }

        if (collision.gameObject.tag == "Gold")
        {
            LoserReword.SetActive(true);
        }

        if (collision.gameObject.tag == "BlueDount" && GetComponent<CopScripte>().enabled == true)
        {
            BlueDountButton.SetActive(true);
            Lodedd = true;
        }
    }

    public void StartDonutEffect()
    {
        Stamina = 100;
        DountBotton.SetActive(false);
    }

    public void CloseBlueDountButton()
    {
        BlueDountButton.SetActive(false);
    }

    void Rewords()
    {
        if (FindObjectOfType<GameManager>().Money >= 10000)
        {
            LoserReword.SetActive(true);
        }

        if (FindObjectOfType<GameManager>().ThiefToLock == FindObjectOfType<GameManager>().ThiefNumber && FindObjectOfType<GameManager>().PlayersRaedy >= 2 && FindObjectOfType<GameManager>().ThiefNumber != 0)
        {
            WinerReword.SetActive(true);
        }
    }

    #region NetWork Comuniction

    [Command]
    void CmdImCop()
    {
        RpcImCop();
    }

    [ClientRpc]
    void RpcImCop()
    {
        gameObject.tag = "Cop";
    }
    #endregion

    #region Skins

    void ChoseStartAnim()
    {
        if(FindObjectOfType<DataShop>().UserSkin == 0)
        {
            Anim.Play("C00S");
        }

        if(FindObjectOfType<DataShop>().UserSkin == 1)
        {
            Anim.Play("C01S");
        }

        if (FindObjectOfType<DataShop>().UserSkin == 2)
        {
            Anim.Play("C02S");
        }

    }

    void CopSkin00()
    {
        if(FindObjectOfType<DataShop>().UserSkin == 0)
        {
            if (LastX.x < CurrentX.x)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C00R", true);
                Anim.SetBool("C00L", false);
                Anim.SetBool("C00S", false);
            }
            else if (LastX.x > CurrentX.x)
            {
                Anim.SetBool("C00L", true);
                Anim.SetBool("C00R", false);
                Anim.SetBool("C00S", false);
            }
            if (MoveH == 0)
            {
                FootSteps.SetActive(false);
                Anim.SetBool("C00S", true);
                Anim.SetBool("C00R", false);
                Anim.SetBool("C00L", false);

            }
        }
    }

    void CopSkin01()
    {
        if(FindObjectOfType<DataShop>().UserSkin == 1)
        {
            if (LastX.x < CurrentX.x)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C01R", true);
                Anim.SetBool("C01L", false);
                Anim.SetBool("C01S", false);
            }
            else if (LastX.x > CurrentX.x)
            {
                Anim.SetBool("C01L", true);
                Anim.SetBool("C01R", false);
                Anim.SetBool("C01S", false);
            }
            if (MoveH == 0)
            {
                FootSteps.SetActive(false);
                Anim.SetBool("C01S", true);
                Anim.SetBool("C01R", false);
                Anim.SetBool("C01L", false);

            }
        }
    }

    void CopSkin02()
    {
        if (FindObjectOfType<DataShop>().UserSkin == 2)
        {
            if (LastX.x < CurrentX.x)
            {
                FootSteps.SetActive(true);
                Anim.SetBool("C02R", true);
                Anim.SetBool("C02L", false);
                Anim.SetBool("C02S", false);
            }
            else if (LastX.x > CurrentX.x)
            {
                Anim.SetBool("C02L", true);
                Anim.SetBool("C02R", false);
                Anim.SetBool("C02S", false);
            }
            if (MoveH == 0)
            {
                FootSteps.SetActive(false);
                Anim.SetBool("C02S", true);
                Anim.SetBool("C02R", false);
                Anim.SetBool("C02L", false);

            }
        }
    }

    private void OnDestroy()
    {
        //NetworkManager.singleton.OnDropConnection(true, "Cop");
    }

    #endregion

}

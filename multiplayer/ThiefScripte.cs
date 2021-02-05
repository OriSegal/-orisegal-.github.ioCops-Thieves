using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ThiefScripte : NetworkBehaviour
{
    private SpriteRenderer MySpriteRenderer;
    public Sprite Thief;
    private Rigidbody2D MyRigidbody;
    private Animator Anim;
    public Slider StaminaSlider;
    private Vector2 LastX;
    private Vector2 CurrentX;
    public float Speed = 7f;
    private float MoveH = 0f;
    private float MoveV = 0f;
    private int tapCount;
    [SerializeField]
    private float Stamina = 100;
    public Joystick joystick;
    public GameObject Buttom;
    public GameObject PlayerUI;
    private bool SecondTimeInJail = false;
    [SerializeField]
    private bool IsRuning;
    public GameObject FootSteps;
    public AudioSource PrisonDoor;
    public GameObject Handcuffe;

    public GameObject WinerReword;
    public GameObject LoserReword;

    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        MySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (MySpriteRenderer.sprite == null)
        {
            MySpriteRenderer.sprite = Thief;
        }
        MyRigidbody = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        LastX = transform.position;
        gameObject.tag = "Thief";
        CmdImThief();
        if (gameObject.tag == "Thief")
        {
            Buttom.SetActive(false);
        }
        ChoseStratAnim();
    }

    void FixedUpdate()
    {
        StaminaSlider.value = Stamina;
        CurrentX = transform.position;
        JoystickMovement();
        Rewords();
        SentToJail();
        DoubleTap();
        Runing();
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
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip2.transform.position, 100 + Time.deltaTime);

        }

        if(Vector2.Distance(transform.position, Pip2.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip1.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip3.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip4.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip4.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip3.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip5.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip6.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip6.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip5.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip7.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip8.transform.position, 100 + Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Pip8.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip7.transform.position, 100 + Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, Pip9.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip10.transform.position, 100 + Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, Pip10.transform.position) < 2)
        {
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Pip9.transform.position, 100 + Time.deltaTime);
        }
    }

    void JoystickMovement()
    {

        MoveH = joystick.Horizontal;
        MoveV = joystick.Vertical;
        MyRigidbody.velocity = new Vector2(MoveH * Speed, MoveV * Speed);
        ThiefSkin00();
        ThiefSkin01();
        ThiefSkin02();
        LastX = transform.position;

    }

    void SentToJail()
    {
        if(Handcuffe.activeSelf == true)
        {
            GameObject Jail = GameObject.FindGameObjectWithTag("Jail");
            MyRigidbody.position = Vector2.MoveTowards(transform.position, Jail.transform.position, 1000 + Time.deltaTime);
            if (SecondTimeInJail == false)
            {
                CmdSomeOneInJailUp();
            }
        }
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jail" && SecondTimeInJail == false)
        {          
            CmdCurrentPname();
            SecondTimeInJail = true;
        }

        if(collision.gameObject.tag == "Jail")
        {
            PrisonDoor.Play();
            Handcuffe.SetActive(false);
        }

        if (collision.gameObject.tag == "Shoot")
        {
            Speed = 6f;
            Stamina = 0;
            Invoke("SetSpeedAgian", 5);
        }

        if (collision.gameObject.tag == "Trhowable")
        {
            if (GetComponent<ThiefScripte>().enabled == true)
            {
                Handcuffe.SetActive(true);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trap")
        {
            Speed = 6f;
            Stamina = 0f;
            Invoke("SetSpeedAgian", 7);
        }

        if (collision.gameObject.tag == "Gold")
        {
            LoserReword.SetActive(true);
        }
    }

    void SetSpeedAgian()
    {
        Speed = 8f;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jail")
        {
            PlayerUI.SetActive(false);
        }

        if (FindObjectOfType<GameManager>().ReleseThatPresoner == GetComponent<PlayerSetup>().Pname && collision.gameObject.tag == "Jail")
        {
            GameObject FreePoint = GameObject.FindGameObjectWithTag("FreePoint");
            MyRigidbody.position = Vector2.MoveTowards(transform.position, FreePoint.transform.position, 100 + Time.deltaTime);
        }
    }

    public void OpenAtm()
    {
        if(FindObjectOfType<Atm>().ReadyToOpen == true)
        {
            CmdHitAtm();
        }
    }

    void Rewords()
    {
        if (FindObjectOfType<GameManager>().Money >= 10000)
        {
            WinerReword.SetActive(true);
        }

        if(FindObjectOfType<GameManager>().ThiefToLock == FindObjectOfType<GameManager>().ThiefNumber && FindObjectOfType<GameManager>().PlayersRaedy >= 2 && FindObjectOfType<GameManager>().ThiefNumber != 0)
        {
            LoserReword.SetActive(true);
        }
    }

    #region NetWork Comuniction

    [Command]
    void CmdImThief()
    {
        RpcImThief();
    }

    [ClientRpc]
    void RpcImThief()
    {
        gameObject.tag = "Thief";
    }

    [Command]
    void CmdCurrentPname()
    {
        RpcCurrentPname();
    }

    [ClientRpc]
    void RpcCurrentPname()
    {
        FindObjectOfType<GameManager>().CurrentPresoner = GetComponent<PlayerSetup>().Pname;
    }

    [Command]
    void CmdSomeOneInJailUp()
    {
        RpcSomeOneInJailUp();
    }

    [ClientRpc]
    void RpcSomeOneInJailUp()
    {
        FindObjectOfType<GameManager>().SomeOneInJail++;
    }
    [Command]
    void CmdHitAtm()
    {
        RpcHitAtm();
    }
    [ClientRpc]
    void RpcHitAtm()
    {
        FindObjectOfType<Atm>().TimeToOpen = FindObjectOfType<Atm>().TimeToOpen - 10;
    }

    private void OnDestroy()
    {
        if(gameObject.tag == "Thief")
        {
            NetworkManager.singleton.OnDropConnection(true, "Thief");
        }
        
        if(gameObject.tag == "Cop")
        {
            NetworkManager.singleton.OnDropConnection(true, "Cop");
        }
    }

    #endregion

    #region Animations

    void ChoseStratAnim()
    {
        if (FindObjectOfType<DataShop>().UserSkinThiefs == 0)
        {
            Anim.Play("T00S");
        }

        if (FindObjectOfType<DataShop>().UserSkinThiefs == 1)
        {
            Anim.Play("T01S");
        }

        if (FindObjectOfType<DataShop>().UserSkinThiefs == 2)
        {
            Anim.Play("T02S");
        }

    }

    void ThiefSkin00()
    {
        if (LastX.x < CurrentX.x)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T00R", true);
            Anim.SetBool("T00L", false);
            Anim.SetBool("T00S", false);
        }
        else if (LastX.x > CurrentX.x)
        {
            Anim.SetBool("T00L", true);
            Anim.SetBool("T00R", false);
            Anim.SetBool("T00S", false);
        }
        if (MoveH == 0)
        {
            FootSteps.SetActive(false);
            Anim.SetBool("T00S", true);
            Anim.SetBool("T00R", false);
            Anim.SetBool("T00L", false);
        }
    }

    void ThiefSkin01()
    {
        if (LastX.x < CurrentX.x)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T01R", true);
            Anim.SetBool("T01L", false);
            Anim.SetBool("T01S", false);
        }
        else if (LastX.x > CurrentX.x)
        {
            Anim.SetBool("T01L", true);
            Anim.SetBool("T01R", false);
            Anim.SetBool("T01S", false);
        }
        if (MoveH == 0)
        {
            FootSteps.SetActive(false);
            Anim.SetBool("T01S", true);
            Anim.SetBool("T01R", false);
            Anim.SetBool("T01L", false);
        }
    }

    void ThiefSkin02()
    {
        if (LastX.x < CurrentX.x)
        {
            FootSteps.SetActive(true);
            Anim.SetBool("T02R", true);
            Anim.SetBool("T02L", false);
            Anim.SetBool("T02S", false);
        }
        else if (LastX.x > CurrentX.x)
        {
            Anim.SetBool("T02L", true);
            Anim.SetBool("T02R", false);
            Anim.SetBool("T02S", false);
        }
        if (MoveH == 0)
        {
            FootSteps.SetActive(false);
            Anim.SetBool("T02S", true);
            Anim.SetBool("T02R", false);
            Anim.SetBool("T02L", false);
        }
    }


    #endregion
}

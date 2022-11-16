using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.SceneManagement;

public class TESTplayermove : MonoBehaviour
{
    //角色控制
    float y = 0;
    public float WalkSpeed = 5.0f;
    public float RunSpeed = 2.5f;
    public float JumpSpeed = 25.0f;
    public float Gravity = 40.0f;
    public float RotateSpeed = 0.5f;
    private Animator m_Animator;
    bool ishurt = false;
    float hurtTime = 0;
    private Vector3 MoveDirection = Vector3.zero;

    //血量控制
    public GameObject HPbar;
    public Text text;
    private bool isbeclikck;
    private Color colorOrgion = new Color(0, 0, 0, 1);//默認黑色
    private float Alpha = 1.0f;
    Timer timer = new Timer(2000);
    public Image MonsterImage;

    //技能冷卻
    public GameObject firepoint;
    public GameObject bullet;
    public float PowerZ = 20f;
    public Text t_Gameoverr;
    public SkillColdDown skillBtnUI;
    public SkillColdDown skillATKUI;
    private bool isHealing;
    public float HealingTime;
    public float currentHealingTime;

    //特效
    public GameObject B;
    bool isFire;
    bool isHealth;
    public float timerA;
    public float timerB;
    public float AcurrentTimer;
    public float BcurrentTimer;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        text.text = "";
        //t_Gameoverr.text = "";
        text.color = new Color(0, 0, 0, 0);
        timer.Elapsed += (object sender, ElapsedEventArgs e) =>
        {
            isbeclikck = true;
        };
        timer.AutoReset = false;
        timer.Enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //MonsterImage.fillAmount = HP / 10;
        
        CharacterController boy = GetComponent<CharacterController>();
        m_Animator.SetInteger("Status", 0);
        
        float currSpeed = WalkSpeed;
        if (boy.isGrounded)
        {
            MoveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                y = 180;
                transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));
                //MoveDirection *= -WalkSpeed;
                m_Animator.SetInteger("Status", 1);
            }


            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                y = 0;
                //MoveDirection *= WalkSpeed;
                transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));
                m_Animator.SetInteger("Status", 1);
            }


            if (Input.GetKey(KeyCode.LeftShift))
            {
                currSpeed = RunSpeed;
                if(RunSpeed >=0)
                {
                    m_Animator.SetInteger("Status", 2);
                }
               //m_Animator.SetInteger("Status", 2);
            }


            if (Input.GetButton("Jump"))
            {
                MoveDirection.y = JumpSpeed;
               m_Animator.SetInteger("Status", 3);
            }
        }

        MoveDirection.y -= Gravity * Time.deltaTime;

        boy.Move((MoveDirection * currSpeed) * Time.deltaTime);

        if (isbeclikck)
        {
            Alpha = Alpha - (Time.deltaTime);
            colorOrgion.a = Alpha;
            text.color = colorOrgion;
        }

        if (colorOrgion.a <= 0)
        {
            isbeclikck = false;
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           m_Animator.SetInteger("Status", 4);
            SkillQ();
            isHealth = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
           m_Animator.SetInteger("Status", 5);
            SkillB();
            isFire = true;
        }

        if (isFire)
        {
            AcurrentTimer += Time.deltaTime;
            if (AcurrentTimer >= timerA)
            {
                isFire = false;
                AcurrentTimer = 0;
            }
        }

        if (isHealth)
        {
            B.SetActive(true);
            BcurrentTimer += Time.deltaTime;
            if (BcurrentTimer >= timerB)
            {
                isHealth = false;
                B.SetActive(false);
                BcurrentTimer = 0;
            }
        }
        if (isHealing)
        {
            HPbar.transform.Translate(0.1f, 0, 0);
            currentHealingTime += Time.deltaTime;
            if(HPbar.transform.localPosition.x >= 0)//回血溢出
            {
                HPbar.transform.localPosition = new Vector3(0, 0, 0);
                isHealing = false;
            }
            if(currentHealingTime > HealingTime)
            {
                isHealing = false;
                currentHealingTime = 0;
            }
        }

        if (ishurt == true)
        {
            GetComponent<Animator>().SetBool("hurt", true);
            ishurt = false;
        }
        else
        {
            GetComponent<Animator>().SetBool("hurt", false);
        }
        Dead();
    }
    public void DeadZone()  //毒圈
    {
        ishurt = true;
        if (isHealing == false)
        { 
            HPbar.transform.Translate(-2f, 0, 0);
            //m_Animator.SetInteger("Status", 6);
        }
    }
    private void OnTriggerStay(Collider other)  //毒圈
    {
        if (other.gameObject.tag == "Death")
        {
            DeadZone();
            return;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Rock")
        {
            Debug.Log("RRRRRR");
            HPbar.transform.Translate(-80f, 0, 0);
        }
    }
    public void SkillB()//攻擊技能(單純控制冷卻)
    {
        if (skillATKUI.isCoolingDown())
        {
            return;
        }
        Rigidbody rb = Instantiate(bullet, firepoint.transform.position, transform.rotation).GetComponent<Rigidbody>();
        rb.velocity = transform.TransformDirection(new Vector3(0, 0, PowerZ));
        isbeclikck = true;
        skillATKUI.useskillATK();
    }
    public void SkillQ()  //治癒技能
    {
        if (HPbar.transform.localPosition.x >= 0)//判斷是否為滿血
        {
            //x = 0;
            text.text = "現在狀態為滿血無法使用";
            Alpha = 1;
            isbeclikck = true;
            return;
        }
        if(skillBtnUI.isCoolingDown()) //判讀是否冷卻中
        {
            return;
        }
        skillBtnUI.useskillQ();
        isHealing = true;
    }
    public void Black()  //技能遮罩
    {
        text.color = new Color(0, 0, 0, 1);
        Alpha = 1;
        colorOrgion.a = 1.0f;
        timer.Start();
    }
    private void Timer_Elapsed(object sender,ElapsedEventArgs e)
    {
        isbeclikck = true;
    }

    void Dead()
    {
        
        if (HPbar.transform.localPosition.x <= -500)
        {
            hurtTime += Time.deltaTime;
            ishurt = false;
            GetComponent<Animator>().SetBool("hurt", false);
            GetComponent<Animator>().SetBool("die", true);
            //t_Gameoverr.text = "Game Over";
            if (hurtTime >= 3)
            {
                Destroy(gameObject);
                LoadScene();
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("die", false);
        }
        void LoadScene()
        {
            hurtTime = 0;
            SceneManager.LoadScene(4);
        }
    }
}

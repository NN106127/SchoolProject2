using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class Boss : MonoBehaviour
{
    public AudioSource bossmusic;
    public AudioSource atk1;
    public AudioSource atk2;
    public AudioSource hurt;
    private Animator m_Animator;
    public GameObject TargetPlayer;// 玩家
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject Effect01;  // 毒氣特效
    public GameObject Effect02;
    public GameObject Effect03;
    public int i;              // 隨機紀能編號
    public int n = 0;          // 控制子彈只射一顆
    private CharacterController controller;
    public string status = "patrol";
    public string prevStatus = "patrol";
    public float ColdTimer = 0;//技能之間冷卻

    // Boss血條
    public GameObject bosscharter;
    public Boss boss;
    public const int maxHealth = 500;
    public int currentHealth = maxHealth;
    //血量條
    public GameObject bossbar;
    public RectTransform HealthBar, Hurt;
    public RectTransform barSet;
    public float maxHp = 500;
    public float currHp = 500;
    //影片
    public float bosstime=0;
    public VideoPlayer aaa;
    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {
        Hurt.sizeDelta = new Vector2(boss.currHp, HealthBar.sizeDelta.y);
        m_Animator = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("aoe", false);
        GetComponent<Animator>().SetBool("atk", false);
        bossbar.SetActive(false);
        controller = GetComponent<CharacterController>();
        Effect01.SetActive(false);
        Effect02.SetActive(false);
        Effect03.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //將綠色血條同步到當前血量長度
        HealthBar.sizeDelta = new Vector2(boss.currHp, HealthBar.sizeDelta.y);

        //呈現傷害量
        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)
        {
            //讓傷害量(紅色血條)逐漸追上當前血量
            Hurt.sizeDelta += new Vector2(-10, 0) * Time.deltaTime * 10;
        }
        if (Hurt.sizeDelta.x <= 0)
        {
            bossbar.SetActive(false);
        }

        if(currHp <= 0)
        {
            
            status = "Dead";
            
            Destroy(gameObject,21);
            bossmusic = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
            bossmusic.Stop();
            
            //bosscharter.SetActive(false);


        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            hurt.Play();
            currHp -= 100;
        }

        if (status == "Random")
        {
            GetComponent<Animator>().SetBool("aoe", false);
            GetComponent<Animator>().SetBool("atk", false);
            n = 0;
            Effect01.SetActive(false);
            Effect02.SetActive(false);
            Effect03.SetActive(false);
            ColdTimer = 0;
            RandomSkill();
            prevStatus = status;
            status = "Atk";
        }

        if (status == "Cold")
        {
            
            DoColdTime();
            if (ColdTimer >= 5)
            {
                
                Debug.Log("Random");
                prevStatus = status;
                status = "Random";
            }
        }

        if(status == "Dead")
        {
            
            Effect01.SetActive(false);
            Effect02.SetActive(false);
            Effect03.SetActive(false);
            bosstime += Time.deltaTime;
            img.SetActive(true);
            aaa.Play();
            if (bosstime >= 19)
            {

                //img.SetActive(false);
                SceneManager.LoadScene(0);

            }

        }

        if (status == "Atk")
        {
            if (i == 1)
            {
                atk2.Play();
                //m_Animator.SetInteger("Status", 1);
                GetComponent<Animator>().SetBool("atk", true);
                if (n == 0)
                {
                    
                    DoSkill01();
                    n = 1;
                    prevStatus = status;
                    status = "Cold";
                }
            }

            if (i == 2)
            {
                atk1.Play();
                //m_Animator.SetInteger("Status", 2);
                GetComponent<Animator>().SetBool("aoe", true);
                DoSkill02();
                prevStatus = status;
                status = "Cold";
            }

            if (i == 3)
            {
                atk1.Play();
                //m_Animator.SetInteger("Status", 2);
                GetComponent<Animator>().SetBool("aoe", true);
                DoSkill03();
                prevStatus = status;
                status = "Cold";
            }

            if (i == 4)
            {
                atk1.Play();
                //m_Animator.SetInteger("Status", 2);
                GetComponent<Animator>().SetBool("aoe", true);
                DoSkill04();
                prevStatus = status;
                status = "Cold";
            }
        }

    }

    void DoColdTime() // 冷卻時間
    {

        ColdTimer += Time.deltaTime;
    }

    void RandomSkill() // 隨機抽技能
    {
        i = Random.Range(1, 5);
    }

    void DoSkill01()  // 技能一
    {
        //m_Animator.SetInteger("Status", 1);
        GetComponent<Animator>().SetBool("atk", true);
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
    }

    void DoSkill02()  // 技能二
    {
        //m_Animator.SetInteger("Status", 2);
        GetComponent<Animator>().SetBool("aoe", true);
        Effect01.SetActive(true);
    }
    
    void DoSkill03()  // 技能二
    {

        //m_Animator.SetInteger("Status", 2);
        GetComponent<Animator>().SetBool("aoe", true);
        Effect02.SetActive(true);
    }
    void DoSkill04()  // 技能二
    {
        //m_Animator.SetInteger("Status", 2);
        GetComponent<Animator>().SetBool("aoe", true);
        Effect03.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            status = "Random";
            bossbar.SetActive(true);
        }

        if (other.gameObject.tag == "bullet")
        {
            hurt.Play();
            currHp -= 75;
        }
    }

    }

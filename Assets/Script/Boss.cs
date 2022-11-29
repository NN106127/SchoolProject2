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
    public GameObject TargetPlayer;// ���a
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject Effect01;  // �r��S��
    public GameObject Effect02;
    public GameObject Effect03;
    public int i;              // �H������s��
    public int n = 0;          // ����l�u�u�g�@��
    private CharacterController controller;
    public string status = "patrol";
    public string prevStatus = "patrol";
    public float ColdTimer = 0;//�ޯध���N�o

    // Boss���
    public GameObject bosscharter;
    public Boss boss;
    public const int maxHealth = 500;
    public int currentHealth = maxHealth;
    //��q��
    public GameObject bossbar;
    public RectTransform HealthBar, Hurt;
    public RectTransform barSet;
    public float maxHp = 500;
    public float currHp = 500;
    //�v��
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
        
        //�N������P�B���e��q����
        HealthBar.sizeDelta = new Vector2(boss.currHp, HealthBar.sizeDelta.y);

        //�e�{�ˮ`�q
        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)
        {
            //���ˮ`�q(������)�v���l�W��e��q
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

    void DoColdTime() // �N�o�ɶ�
    {

        ColdTimer += Time.deltaTime;
    }

    void RandomSkill() // �H����ޯ�
    {
        i = Random.Range(1, 5);
    }

    void DoSkill01()  // �ޯ�@
    {
        //m_Animator.SetInteger("Status", 1);
        GetComponent<Animator>().SetBool("atk", true);
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
    }

    void DoSkill02()  // �ޯ�G
    {
        //m_Animator.SetInteger("Status", 2);
        GetComponent<Animator>().SetBool("aoe", true);
        Effect01.SetActive(true);
    }
    
    void DoSkill03()  // �ޯ�G
    {

        //m_Animator.SetInteger("Status", 2);
        GetComponent<Animator>().SetBool("aoe", true);
        Effect02.SetActive(true);
    }
    void DoSkill04()  // �ޯ�G
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

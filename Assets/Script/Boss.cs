using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
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
    public Boss boss;
    public const int maxHealth = 500;
    public int currentHealth = maxHealth;
    //血量條
    public GameObject bossbar;
    public RectTransform HealthBar, Hurt;
    public RectTransform barSet;
    public float maxHp = 500;
    public float currHp = 500;


    public float TraceRadius;// 追逐距離
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
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

        if (status == "Random")
        {
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
            if (ColdTimer >= 3)
            {
                Debug.Log("Random");
                prevStatus = status;
                status = "Random";
            }
        }

        if (status == "Atk")
        {
            if (i == 1)
            {
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
                DoSkill02();
                prevStatus = status;
                status = "Cold";
            }

            if (i == 3)
            {
                DoSkill03();
                prevStatus = status;
                status = "Cold";
            }

            if (i == 4)
            {
                DoSkill04();
                prevStatus = status;
                status = "Cold";
            }
        }

        // 追逐
        float dist = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        if(dist <= 30)
        {
            Vector3 dir = (TargetPlayer.transform.position - transform.position).normalized;
            controller.Move(dir * Speed * Time.deltaTime);
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
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
    }

    void DoSkill02()  // 技能二
    {
        Effect01.SetActive(true);
    }
    void DoSkill03()  // 技能二
    {
        Effect02.SetActive(true);
    }
    void DoSkill04()  // 技能二
    {
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
            currHp -= 100;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, TraceRadius);
    }

}

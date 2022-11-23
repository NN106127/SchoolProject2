using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
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
    public Boss boss;
    public const int maxHealth = 500;
    public int currentHealth = maxHealth;
    //��q��
    public GameObject bossbar;
    public RectTransform HealthBar, Hurt;
    public RectTransform barSet;
    public float maxHp = 500;
    public float currHp = 500;


    public float TraceRadius;// �l�v�Z��
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

        // �l�v
        float dist = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        if(dist <= 30)
        {
            Vector3 dir = (TargetPlayer.transform.position - transform.position).normalized;
            controller.Move(dir * Speed * Time.deltaTime);
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
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
    }

    void DoSkill02()  // �ޯ�G
    {
        Effect01.SetActive(true);
    }
    void DoSkill03()  // �ޯ�G
    {
        Effect02.SetActive(true);
    }
    void DoSkill04()  // �ޯ�G
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

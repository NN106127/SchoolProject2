using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject TargetPlayer;// 玩家
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject Effect;  // 毒氣特效
    public int i;              // 隨機紀能編號
    public int n = 0;          // 控制子彈只射一顆
    private CharacterController controller;
    public string status = "patrol";
    public string prevStatus = "patrol";
    public float ColdTimer = 0;//技能之間冷卻

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (status == "Random")
        {
            n = 0;
            Effect.SetActive(false);
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
        }
    }

    void DoColdTime() // 冷卻時間
    {
        ColdTimer += Time.deltaTime;
    }

    void RandomSkill() // 隨機抽技能
    {
        i = Random.Range(1, 3);
    }

    void DoSkill01()  // 技能一
    {
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
    }

    void DoSkill02()  // 技能二
    {
        Effect.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            status = "Random";
        }
    }
}

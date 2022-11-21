using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject TargetPlayer;// ���a
    public GameObject bullet;
    public GameObject firePoint;
    public GameObject Effect;  // �r��S��
    public int i;              // �H������s��
    public int n = 0;          // ����l�u�u�g�@��
    private CharacterController controller;
    public string status = "patrol";
    public string prevStatus = "patrol";
    public float ColdTimer = 0;//�ޯध���N�o

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

    void DoColdTime() // �N�o�ɶ�
    {
        ColdTimer += Time.deltaTime;
    }

    void RandomSkill() // �H����ޯ�
    {
        i = Random.Range(1, 3);
    }

    void DoSkill01()  // �ޯ�@
    {
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
    }

    void DoSkill02()  // �ޯ�G
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

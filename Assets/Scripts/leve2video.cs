using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class leve2video : MonoBehaviour
{
    public int m_seconds;                 //�˼ƭp�ɸg���⪺�`���
    public VideoPlayer aaa;
    public int m_min;              //�Ω�]�w�˼ƭp�ɪ�����
    public int m_sec;              //�Ω�]�w�˼ƭp�ɪ����

    public GameObject img;
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            img.SetActive(true);
            aaa.Play();
            StartCoroutine(Countdown());


        }
    }
    IEnumerator Countdown()
    {
        
        m_seconds = (m_min * 60) + m_sec;       //�N�ɶ����⬰���

        while (m_seconds > 0)                   //�p�G�ɶ��|������
        {
            yield return new WaitForSeconds(1); //���Ԥ@��A������

            m_seconds--;                        //�`��ƴ� 1
            m_sec--;                            //�N��ƴ� 1

            if (m_sec < 0 && m_min > 0)         //�p�G��Ƭ� 0 �B�����j�� 0
            {
                m_min -= 1;                     //���N������h 1
                m_sec = 59;                     //�A�N��Ƴ]�� 59
            }
            else if (m_sec < 0 && m_min == 0)   //�p�G��Ƭ� 0 �B�����j�� 0
            {
                m_sec = 0;                      //�]�w��Ƶ��� 0
            }

        }

        yield return new WaitForSeconds(1);   //�ɶ������ɡA��� 00:00 ���d�@��
        img.SetActive(false);

    }
}

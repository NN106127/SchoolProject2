using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //�ϥ�Unity UI�{���w�C
using UnityEngine.SceneManagement;



public class videoplay : MonoBehaviour
{

    public int m_seconds;                 //�˼ƭp�ɸg���⪺�`���

    public int m_min;              //�Ω�]�w�˼ƭp�ɪ�����
    public int m_sec;              //�Ω�]�w�˼ƭp�ɪ����

    public GameObject img;  

    void Start()
    {
        StartCoroutine(Countdown());   //�I�s�˼ƭp�ɪ���{
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
        SceneManager.LoadScene(2);       //�ɶ������ɡA�e���X�{ GAME OVER

    }
}
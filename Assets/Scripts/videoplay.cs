using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //ㄏノUnity UI祘Α畐
using UnityEngine.SceneManagement;



public class videoplay : MonoBehaviour
{

    public int m_seconds;                 //计璸竒传衡羆计

    public int m_min;              //ノ砞﹚计璸だ牧
    public int m_sec;              //ノ砞﹚计璸计

    public GameObject img;  

    void Start()
    {
        StartCoroutine(Countdown());   //㊣计璸祘
    }

    IEnumerator Countdown()
    {
        
        m_seconds = (m_min * 60) + m_sec;       //盢丁传衡计

        while (m_seconds > 0)                   //狦丁﹟ゼ挡
        {
            yield return new WaitForSeconds(1); //单Ω磅︽

            m_seconds--;                        //羆计搭 1
            m_sec--;                            //盢计搭 1

            if (m_sec < 0 && m_min > 0)         //狦计 0 だ牧 0
            {
                m_min -= 1;                     //盢だ牧搭 1
                m_sec = 59;                     //盢计砞 59
            }
            else if (m_sec < 0 && m_min == 0)   //狦计 0 だ牧 0
            {
                m_sec = 0;                      //砞﹚计单 0
            }
            
        }

        yield return new WaitForSeconds(1);   //丁挡陪ボ 00:00 氨痙
        SceneManager.LoadScene(2);       //丁挡礶瞷 GAME OVER

    }
}
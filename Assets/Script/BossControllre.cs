using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControllre : MonoBehaviour
{
    public AudioSource m_audio1;
    public AudioSource m_audio2;
    public GameObject Boss;
    public Text text;
    //public float Timer;
    // Start is called before the first frame update
    void Start()
    {
        m_audio1 = GameObject.FindGameObjectWithTag("background").GetComponent<AudioSource>();
        m_audio1.Play();
        Boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            text.text = "»°§Ö°kÂ÷!!";
            Boss.SetActive(true);
            m_audio1.Stop();
            m_audio2.Play();
        }
    }
}

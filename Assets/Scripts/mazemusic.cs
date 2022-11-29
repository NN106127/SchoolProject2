using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazemusic : MonoBehaviour
{
    public AudioSource m_audio1;
    public AudioSource m_audio2;
    // Start is called before the first frame update
    void Start()
    {
        m_audio1 = GameObject.FindGameObjectWithTag("background").GetComponent<AudioSource>();
        m_audio1.Stop();
        m_audio2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

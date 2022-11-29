using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgroundmusic : MonoBehaviour
{
    public AudioSource m_audio1;
   
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(m_audio1);
        
        m_audio1.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class startbutton : MonoBehaviour
{
    public AudioSource m_audio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ChangeScence(string scencename)
    {
        m_audio.Play();
        SceneManager.LoadScene(1);
        SceneManager.LoadSceneAsync(scencename);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

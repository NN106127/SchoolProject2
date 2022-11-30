using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escui : MonoBehaviour
{
    [SerializeField] Transform UIPanel;
    bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        UIPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Pause();
            Debug.Log("Pause");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
        {
            unPause();
            Debug.Log("UnPause");
        }
    }

    void Pause()
    {
        isPause = true;
        UIPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void unPause()
    {
        isPause = false;
        UIPanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openui : MonoBehaviour
{
    public Text text01;
    // Start is called before the first frame update
    void Start()
    {
        text01.text = "";
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            text01.text = "ESC¶}±Ò¿ï³æ";
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text01.text = "";
            
        }
    }
}

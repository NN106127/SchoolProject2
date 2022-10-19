using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startfind : MonoBehaviour
{
    public Text m_text;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        m_text.text = "±´¯Á°g®c¡A´M§ä¥X¤f";
    }
    private void OnTriggerExit(Collider other)
    {
        m_text.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    //public GameObject Object;//�b�a�W�����~
    //public GameObject OnCoin;//�b��W�����~
    public Text m_text;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;

    // Start is called before the first frame update
    void Start()
    {
        //OnCoin.SetActive(false);//�]�w��l���A
        m_text.text = "";
        
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        image5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (gameObject.name == "���~")
        {
            
            m_text.text = "��E�B�����~";


        }
        else if(gameObject.name == "���~ (1)")
        {
            m_text.text = "��E�B�����~";
        }
        else if (gameObject.name == "���~ (2)")
        {
            m_text.text = "��E�B�����~";
        }
        else if (gameObject.name == "���~ (3)")
        {
            m_text.text = "��E�B�����~";
        }
        else if (gameObject.name == "���~ (4)")
        {
            m_text.text = "��E�B�����~";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.name == "���~" && Input.GetKeyDown(KeyCode.E))
        {
            //OnCoin.SetActive(true);//�}��Ĳ�I�����
            // Object.SetActive(false);
            image1.SetActive(true);
            m_text.text = "";
        }
        else if (gameObject.name == "���~ (1)" && Input.GetKeyDown(KeyCode.E))
        {
            image2.SetActive(true);
            m_text.text = "";
        }
        else if (gameObject.name == "���~ (2)" && Input.GetKeyDown(KeyCode.E))
        {
            image3.SetActive(true);
            m_text.text = "";
        }
        else if (gameObject.name == "���~ (3)" && Input.GetKeyDown(KeyCode.E))
        {
            image4.SetActive(true);
            m_text.text = "";
        }
        else if (gameObject.name == "���~ (4)" && Input.GetKeyDown(KeyCode.E))
        {
            image5.SetActive(true);
            m_text.text = "";
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "Coin")
        {
            m_text.text = "";
            //text02.text = "";
            //text03.text = "";
        }
    }
}

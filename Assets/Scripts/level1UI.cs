using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level1UI : MonoBehaviour
{
    public Text text01;
    //public Text text02;
    //public Text text03;
    // Start is called before the first frame update
    void Start()
    {
        text01.text = "";
        //text02.text = "";
        //text03.text = "";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "plane")
        {
            text01.text = "��LAD���� �ť�����D Shift�b�]";
            //text02.text = "����Shift�i�i��Ĩ�";
            //text03.text = "�ж}�l����";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "plane")
        {
            text01.text = "";
            //text02.text = "";
            //text03.text = "";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

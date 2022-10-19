using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PluzzStart : MonoBehaviour
{
    public GameObject PluzzCanvas;
    public Text StartPluzzText;
    public Text errortext;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;

    // Start is called before the first frame update
    void Start()
    {
        PluzzCanvas.SetActive(false);
        StartPluzzText.text = "";
        errortext.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "PluzzStart")
        {
            StartPluzzText.text = "��E�}�l����";
            

        }

        
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (gameObject.tag == "PluzzStart" && Input.GetKeyDown(KeyCode.E))
        {
            errortext.text = "";

            if ( image1.activeSelf && image2.activeSelf && image3.activeSelf && image4.activeSelf && image5.activeSelf)
            {
                
                StartPluzzText.text = "";
                errortext.text = "";
                
                image1.SetActive(false);
                image2.SetActive(false);
                image3.SetActive(false);
                image4.SetActive(false);
                image5.SetActive(false);
                PluzzCanvas.SetActive(true);
            }
            else
            {
                
                StartPluzzText.text = "";
                errortext.text = "�|���������ϸH���A�@�������A�A�h�a�ϤW���a!";
            }
            

        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        StartPluzzText.text = "";
        errortext.text = "";
    }
}
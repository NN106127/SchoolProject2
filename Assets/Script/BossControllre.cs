using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossControllre : MonoBehaviour
{
    public GameObject Boss;
    public Text text;
    //public float Timer;
    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
}

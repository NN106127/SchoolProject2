using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControllre : MonoBehaviour
{
    public GameObject Boss;
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
            Boss.SetActive(true);
        }
    }
}

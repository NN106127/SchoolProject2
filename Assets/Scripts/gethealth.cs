using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gethealth : MonoBehaviour
{
    private bool isDestroy;
    public GameObject wordbutton;
    public GameObject ai;
    public GameObject player;
    public GameObject health;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ai = GameObject.Find("mob02");
        isDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isDestroy);
        if (ai == null && isDestroy ==false)
        {
            health.SetActive(true);
            wordbutton.SetActive(true);
            isDestroy = true;
        }

        if(player.transform.position.z >= 108)
        {
            wordbutton.SetActive(false);
        }
    }
    
}

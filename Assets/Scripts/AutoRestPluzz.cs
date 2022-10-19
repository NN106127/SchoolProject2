using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRestPluzz : MonoBehaviour
{
    public GameObject[] img = new GameObject[8];
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector2 tmp;
            int ran = Random.Range(0, 7);
            tmp = img[ran].transform.position;
            img[ran].transform.position = img[i].transform.position;
            img[i].transform.position = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
}


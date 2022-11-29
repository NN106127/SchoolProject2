using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endmusic : MonoBehaviour
{
    public AudioSource end;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeSelf == true)
        {
            end.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

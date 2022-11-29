using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluzzGame : MonoBehaviour
{
    public AudioSource puzzlemove;
    public GameObject img;
    public GameObject target;
    public GameObject Currect;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (img.transform.position.x == Currect.transform.position.x && img.transform.position.y == Currect.transform.position.y)
        {
            
        }
    }
    public void ImgMove()
    {
        if (((Mathf.Abs(img.transform.position.x - target.transform.position.x) <= 125) && (img.transform.position.y == target.transform.position.y)) || ((Mathf.Abs(img.transform.position.y - target.transform.position.y) <= 125) && (img.transform.position.x == target.transform.position.x)))
        {
            puzzlemove.Play();
            Vector2 tmp = target.transform.position;
            target.transform.position = img.transform.position;
            img.transform.position = tmp;
        }
    }
}

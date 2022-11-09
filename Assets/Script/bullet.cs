using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    public float Speed = 20;
    float lifetime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);
        lifetime += Time.deltaTime;

        if(lifetime > 3)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //¸I¨ì¼Ä¤H¦©¦å
        if (other.gameObject.tag == "robot")
        {
            Destroy(gameObject);
        }
    }
}

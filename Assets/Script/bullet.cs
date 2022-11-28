using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    float lifetime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPoint : MonoBehaviour
{
    public GameObject bullet;
    float PowerZ = 20f;
    public SkillColdDown skillATKUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (skillATKUI.isCoolingDown())
            {
                return;
            }
            Rigidbody rb = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, PowerZ);
        }
    }
}

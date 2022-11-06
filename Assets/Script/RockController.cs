using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    Rigidbody m_rigidbody;
    public GameObject m_target;
    public float m_force = 20;  // 控制方向大小的合力
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        FlyToTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTarget(GameObject target)
    {
        m_target = target;
    }

    void FlyToTarget()
    {
        if (m_target != null)
        {
            Vector3 direction = (m_target.transform.position - transform.position + Vector3.up).normalized;
            m_rigidbody.AddForce(m_force * direction, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Plane") //必須大小寫一樣
        {
            Debug.Log("hit Plane");
            Destroy(gameObject);
        }
    }
}

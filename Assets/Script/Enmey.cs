using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    public GameObject EnmeyBlood;
    public GameObject TargetPlayer;
    public float Speed;      //�����t��
    public float TurnSpeed;  //��V�t��
    public float TraceRadius;//�l�v�Z��
    float gravity = 20.0f;
    Vector3 moveDirection = Vector3.zero, vDir = Vector3.zero;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= -0.85)
        {
            vDir.y -= gravity * Time.deltaTime;
        }

        EnmeyMove();

        controller.Move((moveDirection + vDir) * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, TraceRadius);
    }

    void EnmeyMove()
    {
        //�P�_�O�_�b�Z����
        float dist = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        if (dist < TraceRadius)
        {
            //�����ݦV���a
            Vector3 relativePos = TargetPlayer.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
            Vector3 dir = (TargetPlayer.transform.position - transform.position).normalized;
            controller.Move(dir * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            EnmeyBlood.transform.Translate(-0.5f, 0, 0);
            if (EnmeyBlood.transform.position.x >= -1)
            {
                Destroy(gameObject);
            }
        }
    }
}
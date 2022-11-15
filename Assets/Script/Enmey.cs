using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    public GameObject TargetPlayer;
    public float Speed;      // �����t��
    public float TurnSpeed;  // ��V�t��
    public float TraceRadius;// �l�v�Z��
    public float ATKRadius;  // �����Z��
    public float PatRadius;
    //float gravity = 20.0f;
    Vector3 moveDirection = Vector3.zero, vDir = Vector3.zero;
    private CharacterController controller;

    private Animator m_Animator;

    public string status = "patrol";   // patrol = ����; chasing = �l�v; dead = ���`;
    public int dmage = -80;

    public Transform[] target;
    public float delta = 0.2f;
    private static int i = 0;
    public float Timer;

    //�Ǫ���q
    public float maxHp = 350;
    public float currHp = 350;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // �窱�A���l�v���P�_
        float dist = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        if (dist < TraceRadius)
        {
            status = "chasing";

            if (dist < ATKRadius)
            {

                status = "atk";
                GetComponent<Animator>().SetBool("status", true);
            }
        }

         else
         {
             status = "patrol";
             GetComponent<Animator>().SetBool("status", false);
         }

        // ���ު��A
        if (status == "patrol")
        {
            if (currHp <= 0)
            {
                Debug.Log("DEAD");
                Destroy(gameObject);
            }
            // ���ަ欰
            DoPatrol();
            Timer = 0;
        }

        if (status == "chasing")
        {
            DoChasing();
        }

        if (status == "dead")
        {
            DoDead();
        }

        if(status == "atk")
        {
            DoATK();
        }
    }

    void DoPatrol()
    {
        
        target[i].position = new Vector3(target[i].position.x, transform.position.y, target[i].position.z);

        transform.LookAt(target[i]);

        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        if (transform.position.x > target[i].position.x - delta && transform.position.x < target[i].position.x + delta && transform.position.z > target[i].position.z - delta && transform.position.z < target[i].position.z + delta)
        {
            i = (i + 1) % target.Length;
        }
        
    }

    void DoChasing()
    {
        
        Vector3 relativePos = TargetPlayer.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
        Vector3 dir = (TargetPlayer.transform.position - transform.position).normalized;
        dir.y = 0;
        controller.Move(dir * Speed * Time.deltaTime);
        
    }

    void DoATK()
    {
       
    }

    void DoDead()
    {
        Debug.Log("Destroy");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, TraceRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ATKRadius);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, PatRadius);
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
            Debug.Log("Hit");
            currHp -= 350;
        }
    }
}
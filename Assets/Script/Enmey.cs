using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmey : MonoBehaviour
{
    public GameObject EnmeyBlood;
    public GameObject TargetPlayer;
    public float Speed;      // 走路速度
    public float TurnSpeed;  // 轉向速度
    public float TraceRadius;// 追逐距離
    public float ATKRadius;  // 攻擊距離
    public float PatRadius;
    //float gravity = 20.0f;
    Vector3 moveDirection = Vector3.zero, vDir = Vector3.zero;
    private CharacterController controller;

    private Animator m_Animator;

    public string status = "patrol";   // patrol = 巡邏; chasing = 追逐; dead = 死亡;

    public Transform[] target;
    public float delta = 0.2f;
    private static int i = 0;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // 巡邏狀態
        if (status == "patrol")
        {
            
            // 巡邏行為
            DoPatrol();
            Timer = 0;

            // 改狀態為死亡的判斷
            if (EnmeyBlood.transform.position.x <= -1)
            {
                status = "dead";
            }
        }

        // 改狀態為追逐的判斷
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
        if (EnmeyBlood.transform.position.x <= -1)
        {
            Speed = 0;
            Destroy(gameObject, 2);
        }
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
        //判斷是否在距離內
        float dist = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        if (dist < TraceRadius)
        {
            
            //漸漸看向玩家
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
            Destroy(gameObject, 2);
            if (EnmeyBlood.transform.position.x <= -1)
            {
                Destroy(gameObject, 2);
            }
        }
    }
}
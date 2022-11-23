using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float TurnSpeed;
    public float radius;
    public float stopradius;
    public GameObject TargetPlayer;// ª±®a
    public float TraceRadius;// °l³v¶ZÂ÷
    public float Speed;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // °l³v
        float dist = Vector3.Distance(transform.position, TargetPlayer.transform.position);
        if (dist < TraceRadius)
        {
            /*Vector3 relativePos = TargetPlayer.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);*/
            Vector3 dir = (TargetPlayer.transform.position - transform.position).normalized;
            controller.Move(dir * Speed * Time.deltaTime);
            /*if (dist < radius)
            {
                Speed = 0;
                controller.Move(dir * Speed * Time.deltaTime);
            }
            if (dist < stopradius)
            {
                Speed = 0;
                controller.Move(dir * Speed * Time.deltaTime);
            }*/
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, TraceRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopradius);
    }
}

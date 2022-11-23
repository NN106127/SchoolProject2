using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2d : MonoBehaviour
{
    float y = 0;
    public float WalkSpeed = 5.0f;
    public float RunSpeed = 2.5f;
    public float JumpSpeed = 25.0f;
    public float Gravity = 40.0f;
    public float RotateSpeed = 0.5f;
    private Animator m_Animator;
    private Vector3 MoveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        
        
        //m_Animator.SetFloat("movespeed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController boy = GetComponent<CharacterController>();
        m_Animator.SetInteger("Status", 0);

        float currSpeed = WalkSpeed;
        if (boy.isGrounded)
        {
            MoveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                y = 180;
                transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));
                //MoveDirection *= -WalkSpeed;
                m_Animator.SetInteger("Status", 1);
            }


            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                y = 0;
                transform.rotation = Quaternion.Euler(new Vector3(0, y, 0));
                //MoveDirection *= WalkSpeed;
                m_Animator.SetInteger("Status", 1);
            }


            if (Input.GetKey(KeyCode.LeftShift))
            {
                currSpeed = RunSpeed;
                if (RunSpeed >= 0)
                {
                    m_Animator.SetInteger("Status", 2);
                }
                //m_Animator.SetInteger("Status", 2);
            }


            if (Input.GetButton("Jump"))
            {
                MoveDirection.y = JumpSpeed;
                m_Animator.SetInteger("Status", 3);
            }
        }

        MoveDirection.y -= Gravity * Time.deltaTime;

        boy.Move((MoveDirection * currSpeed) * Time.deltaTime);
    }
}

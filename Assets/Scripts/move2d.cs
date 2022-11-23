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


        if (boy.isGrounded)
        {

            MoveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal"));
            MoveDirection = transform.TransformDirection(MoveDirection);

            if(Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
            {
                
                MoveDirection *= WalkSpeed;
                //m_Animator.SetFloat("movespeed", 1);
                m_Animator.SetInteger("Status", 1);
            }
            

            if ( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                
                MoveDirection *= WalkSpeed;
                //m_Animator.SetFloat("movespeed", 1);
                m_Animator.SetInteger("Status", 1);
            }
            


            if (Input.GetKey(KeyCode.LeftShift))
            {
                MoveDirection *= RunSpeed;
                m_Animator.SetInteger("Status", 2);
                //m_Animator.SetFloat("movespeed", 2);
            }
            

            if (Input.GetButton("Jump"))
            {
                MoveDirection.y = JumpSpeed;
                m_Animator.SetInteger("Status", 3);
                // m_Animator.SetFloat("movespeed", 25);
            }
            

        }

        
        MoveDirection.y -= Gravity * Time.deltaTime;

        boy.Move(MoveDirection * Time.deltaTime);
    }
}

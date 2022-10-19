using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController boy = GetComponent<CharacterController>();
        m_Animator.SetInteger("Status", 0);

        if (boy.isGrounded)
        {

            MoveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            MoveDirection = transform.TransformDirection(MoveDirection);
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveDirection *= WalkSpeed;
                m_Animator.SetInteger("Status", 1);
            }
                

            if (Input.GetKey(KeyCode.LeftShift))
            {
                MoveDirection *= RunSpeed;
                m_Animator.SetInteger("Status", 2);
            }

            transform.Rotate(0, Input.GetAxis("Horizontal") * RotateSpeed, 0);

            if (Input.GetButton("Jump"))
            {
                MoveDirection.y = JumpSpeed;
                m_Animator.SetInteger("Status", 3);
            }
        }

        MoveDirection.y -= Gravity * Time.deltaTime;

        boy.Move(MoveDirection * Time.deltaTime);
    }
}

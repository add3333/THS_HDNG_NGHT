using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    public float jumpForce = 112f;
    public float moveDistance = 1f;
    public float groundCheckDistance = 0.3f;
    public bool isGrounded = false;

    private bool canJump = true;
    public float jumpDelay = 0.5f; // 점프 지연시간 (초)

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Physics.Raycast((transform.position + Vector3.up * 0.1f), Vector3.down, groundCheckDistance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // 키를 누르고 있는 동안 입력을 받습니다.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isGrounded && canJump && (horizontalInput != 0 || verticalInput != 0))
        {
            canJump = false;
            Invoke("AllowJump", jumpDelay); // 지연시간 후에 AllowJump 메서드를 호출합니다.

            // 약간의 점프
            rb.AddForce(new Vector3(0, jumpForce, 0));

            // 1칸씩 이동
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
            rb.MovePosition(transform.position + moveDirection * moveDistance);

            // 플레이어의 회전을 조절합니다.
            if (moveDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                rb.MoveRotation(newRotation);
            }
        }
    }

    void AllowJump()
    {
        canJump = true;
    }
}
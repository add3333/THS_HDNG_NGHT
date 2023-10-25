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
    public float jumpDelay = 0.5f; // ���� �����ð� (��)

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

        // Ű�� ������ �ִ� ���� �Է��� �޽��ϴ�.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isGrounded && canJump && (horizontalInput != 0 || verticalInput != 0))
        {
            canJump = false;
            Invoke("AllowJump", jumpDelay); // �����ð� �Ŀ� AllowJump �޼��带 ȣ���մϴ�.

            // �ణ�� ����
            rb.AddForce(new Vector3(0, jumpForce, 0));

            // 1ĭ�� �̵�
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
            rb.MovePosition(transform.position + moveDirection * moveDistance);

            // �÷��̾��� ȸ���� �����մϴ�.
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
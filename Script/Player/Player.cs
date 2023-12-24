using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
/*    private bool canIncreaseHealth = true;*/
    public Rigidbody rb;

    public float jumpForce = 112f;
    public float moveDistance = 1f;
    public float groundCheckDistance = 0.3f;
    public bool isGrounded = false;

    private bool canJump = true;
    public float jumpDelay = 0.5f;

    public bool isGameOver = false;
    public Text gameOverText;
    public Text scoreText;
    public Image gameOverImage;
    public Manage manage;

    public GameObject football;
    public int football_score = 0; // �౸�� ���ھ�



    /// <summary>
    /// slider �κ�!!!
    /// </summary>

    public Slider healthSlider;
    public float maxHealth = 60f;
    public float currentHealth ;
    private float timer = 0f;

    private void Awake()
    {
        /// slider ���� �κ�
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = maxHealth;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        manage = FindObjectOfType<Manage>();

    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (isGameOver)
            return;

        if (Physics.Raycast((transform.position + Vector3.up * 0.1f), Vector3.down, groundCheckDistance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isGrounded && canJump && (horizontalInput != 0 || verticalInput != 0))
        {
            canJump = false;
            Invoke("AllowJump", jumpDelay);

            rb.AddForce(new Vector3(0, jumpForce, 0));

            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
            rb.MovePosition(transform.position + moveDirection * moveDistance);

            if (moveDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                rb.MoveRotation(newRotation);
            }
        }

        if (isGrounded && canJump && (horizontalInput != 0 || verticalInput != 0))
        {
            canJump = false;
            Invoke("AllowJump", jumpDelay);

            if (Physics.Raycast(transform.position, Vector3.down, 1f, LayerMask.GetMask("Water")))
            {
                GameOver("You fell into the water!");
            }
        }

        if ( timer >= 1f)
        {
            currentHealth = Mathf.Max(0f, currentHealth - 1f);
            timer = 0f;
            healthSlider.SetValueWithoutNotify(currentHealth);
        }
        else if ( currentHealth <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            isGameOver = true;

            Quaternion newRotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
            rb.MoveRotation(newRotation);
        }

        
    }

    void GameOver(string message)
    {
        isGameOver = true;
        gameOverText.text = message;
        gameOverImage.gameObject.SetActive(true);
/*        manage.HandleGameOver(); // Manage ��ũ��Ʈ�� HandleGameOver �޼��� ȣ��*/
    }

    void AllowJump()
    {
        canJump = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car" || collision.gameObject.tag == "Water")
        {
            /*manage.healthSlider.value = 0f;*/
            gameOverText.gameObject.SetActive(true);
            isGameOver = true;

            currentHealth = 0;
            healthSlider.SetValueWithoutNotify(currentHealth);

            Quaternion newRotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
            rb.MoveRotation(newRotation);



        }
        else if (collision.gameObject.tag == "Football")
        {
            Debug.Log("�౸������");
            // �౸���� �ε�ġ�� football_score ����
            football_score += 1;

            // ���� ���� �౸�� ������ UI �ؽ�Ʈ�� ������Ʈ
            scoreText.text = "Score: " + football_score.ToString();


            // �౸�� ����
            Destroy(collision.gameObject);

            currentHealth = Mathf.Max(0f, currentHealth + 3f);
            timer = 0f;
            healthSlider.SetValueWithoutNotify(currentHealth);

        }
        else if (collision.gameObject.tag == "soceer_goal")
        {
            if (football_score >= 3)
            {
                // ���ھ 3 �̻��̸�,
                
            }
        }
    }

    // �߰��� HandleGameOver �޼���
    public void HandleGameOver()
    {
        // ���� ���� ȭ���� �����ִ� ������ ��ȯ �Ǵ� �ٸ� ���� ����
        Debug.Log("Game Over condition met");

        // �߰��� �Է��� �����ϵ��� ����
        isGameOver = true;

        // ���� ���� ���¿��� ĳ���͸� 180�� ȸ����Ŵ
        Quaternion newRotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
        rb.MoveRotation(newRotation);
    }

/*    void IncreaseHealth()
    {
        // ���� ü���� ������Ű�� UI�� �ݿ�
        manage.currentHealth = Mathf.Min(manage.currentHealth + 3f, manage.maxHealth);
        manage.healthSlider.SetValueWithoutNotify(manage.currentHealth);
    }*/

    /*    private void ResetCanIncreaseHealth()
        {
            canIncreaseHealth = true;
        }*/
}

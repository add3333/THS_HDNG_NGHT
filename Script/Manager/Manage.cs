using UnityEngine;
using UnityEngine.UI;

public class Manage : MonoBehaviour
{
    public Player player;
    private string lastCollisionTag;
    public bool isGameOver_ = false; // �⺻ ���� false



/*    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�浹 �߻�!");

        lastCollisionTag = collision.gameObject.tag;

        if (lastCollisionTag == "Football")
        {
            HandleFootballCollision();
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            *//*            IncreaseEverySecond();*//*

            // ������ ȣ��� InvokeRepeating�� ���
            CancelInvoke("IncreaseEverySecond");

            // Invoke ��� InvokeRepeating ���
            InvokeRepeating("IncreaseEverySecond", 0f, 1f);
            HP_reduced();
            timer = 0f;
        }
    }

    public void HP_reduced()
    {
        if (!isGameOver_)
        {
            currentHealth = Mathf.Max(0f, currentHealth - 1f);
            healthSlider.SetValueWithoutNotify(currentHealth);

        }
        else if (currentHealth <= 0)
        {
            isGameOver_ = true;
        }

        if (isGameOver_)
        {
            healthSlider.value = 0f;
            currentHealth = 0f;
            player.gameOverText.gameObject.SetActive(true);
            player.isGameOver = true;

            Quaternion newRotation = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
            player.rb.MoveRotation(newRotation);
        }


    }

    // �����̴� ���� ����� �� ȣ��Ǵ� �̺�Ʈ �ڵ鷯

    private void HandleFootballCollision()
    {
        currentHealth = Mathf.Min(currentHealth + 3f, maxHealth);
        timer = 0f;
        healthSlider.SetValueWithoutNotify(currentHealth);
    }*/

}

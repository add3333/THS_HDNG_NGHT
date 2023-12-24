using UnityEngine;
using UnityEngine.UI;

public class Manage : MonoBehaviour
{
    public Player player;
    private string lastCollisionTag;
    public bool isGameOver_ = false; // 기본 상태 false



/*    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌 발생!");

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

            // 이전에 호출된 InvokeRepeating을 취소
            CancelInvoke("IncreaseEverySecond");

            // Invoke 대신 InvokeRepeating 사용
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

    // 슬라이더 값이 변경될 때 호출되는 이벤트 핸들러

    private void HandleFootballCollision()
    {
        currentHealth = Mathf.Min(currentHealth + 3f, maxHealth);
        timer = 0f;
        healthSlider.SetValueWithoutNotify(currentHealth);
    }*/

}

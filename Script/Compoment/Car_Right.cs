using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Right : MonoBehaviour
{
    private float speed;


    void Update()
    {
        // X�� ��ġ�� +15���� -3���� õõ�� �̵��մϴ�. (�����ʿ��� �������� �̵�)
        if (transform.position.x > -20)
        {
            transform.Translate(Vector3.back * -speed * Time.deltaTime);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}

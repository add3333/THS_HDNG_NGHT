using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Left : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        // X�� ��ġ�� -5���� +3���� õõ�� �̵��մϴ�.
        if (transform.position.x < 3)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}

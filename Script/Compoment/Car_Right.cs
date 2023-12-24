using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Right : MonoBehaviour
{
    private float speed;


    void Update()
    {
        // X축 위치가 +15에서 -3까지 천천히 이동합니다. (오른쪽에서 왼쪽으로 이동)
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

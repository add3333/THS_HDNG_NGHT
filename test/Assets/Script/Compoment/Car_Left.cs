using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Left : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        // X축 위치가 -5에서 +3까지 천천히 이동합니다.
        if (transform.position.x < 3)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}

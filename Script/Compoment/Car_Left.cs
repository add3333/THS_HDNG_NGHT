/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Left : MonoBehaviour
{
    // Generation 스크립트의 인스턴스를 저장할 변수
    private Generation generationScript;
    public GameObject prefab; // 생성할 객체의 프리팹을 Inspector에서 할당
    private float speed;

    // 목표 위치
    private float targetPositionX = 15f;

    private void Start()
    {
        // Generation 스크립트의 인스턴스를 찾아서 할당
        generationScript = GameObject.FindObjectOfType<Generation>();
    }

    void Update()
    {
        // X축 위치가 -5에서 +3까지 천천히 이동합니다.
        if (transform.position.x < targetPositionX)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        // X 위치가 목표 위치에 도달하면 Generation 스크립트의 메서드 호출
        if (transform.position.x == targetPositionX)
        {
            // Generation 스크립트의 리스트에 값을 추가
            if (generationScript != null)
            {
                // 여기서 프리팹을 사용하여 새로운 객체를 생성
                GameObject newObject = Instantiate(prefab, new Vector3(generationScript.initialPosition_X[0], generationScript.initialPosition_Y[0], generationScript.initialPosition_Z[0]), Quaternion.identity);

                // 추가된 값을 제거
                generationScript.initialPosition_X.RemoveAt(0);
                generationScript.initialPosition_Y.RemoveAt(0);
                generationScript.initialPosition_Z.RemoveAt(0);
            }
            else
            {
                Debug.LogError("Generation script is null.");
            }
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Left : MonoBehaviour
{

    private float speed;

    // 목표 위치
    private float targetPositionX = 15f;

    // Other existing code...
    void Update()
    {
        // X축 위치가 -5에서 +3까지 천천히 이동합니다.
        if (transform.position.x < 15)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
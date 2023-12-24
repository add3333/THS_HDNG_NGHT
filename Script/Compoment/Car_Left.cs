/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Left : MonoBehaviour
{
    // Generation ��ũ��Ʈ�� �ν��Ͻ��� ������ ����
    private Generation generationScript;
    public GameObject prefab; // ������ ��ü�� �������� Inspector���� �Ҵ�
    private float speed;

    // ��ǥ ��ġ
    private float targetPositionX = 15f;

    private void Start()
    {
        // Generation ��ũ��Ʈ�� �ν��Ͻ��� ã�Ƽ� �Ҵ�
        generationScript = GameObject.FindObjectOfType<Generation>();
    }

    void Update()
    {
        // X�� ��ġ�� -5���� +3���� õõ�� �̵��մϴ�.
        if (transform.position.x < targetPositionX)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        // X ��ġ�� ��ǥ ��ġ�� �����ϸ� Generation ��ũ��Ʈ�� �޼��� ȣ��
        if (transform.position.x == targetPositionX)
        {
            // Generation ��ũ��Ʈ�� ����Ʈ�� ���� �߰�
            if (generationScript != null)
            {
                // ���⼭ �������� ����Ͽ� ���ο� ��ü�� ����
                GameObject newObject = Instantiate(prefab, new Vector3(generationScript.initialPosition_X[0], generationScript.initialPosition_Y[0], generationScript.initialPosition_Z[0]), Quaternion.identity);

                // �߰��� ���� ����
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

    // ��ǥ ��ġ
    private float targetPositionX = 15f;

    // Other existing code...
    void Update()
    {
        // X�� ��ġ�� -5���� +3���� õõ�� �̵��մϴ�.
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
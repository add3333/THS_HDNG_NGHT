using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
    public Camera targetCamera;

    void Start()
    {
        // Start �޼ҵ忡�� targetCamera ������ Main Camera�� �Ҵ�
        targetCamera = Camera.main;

        if (targetCamera == null)
        {
            Debug.LogError("Main Camera not found. Make sure you have a Camera tagged as 'MainCamera'.");
        }
    }

    void Update()
    {
        if (targetCamera != null)
        {
            // Canvas�� ī�޶� ��ġ�� ����
            transform.position = targetCamera.transform.position;
            transform.rotation = targetCamera.transform.rotation;
        }
    }
}

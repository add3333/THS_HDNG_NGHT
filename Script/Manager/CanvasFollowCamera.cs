using UnityEngine;

public class CanvasFollowCamera : MonoBehaviour
{
    public Camera targetCamera;

    void Start()
    {
        // Start 메소드에서 targetCamera 변수에 Main Camera를 할당
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
            // Canvas를 카메라 위치에 고정
            transform.position = targetCamera.transform.position;
            transform.rotation = targetCamera.transform.rotation;
        }
    }
}

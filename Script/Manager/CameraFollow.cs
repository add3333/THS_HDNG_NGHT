using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public string playerTag = "Player";
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Transform target;

    // �߰��� ����
    public float fixedRotationX = 0f;
    public float fixedRotationY = 0f;
    public float fixedRotationZ = 0f;
    public Vector3 fixedPosition;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has the tag: " + playerTag);
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // ���ϴ� ȸ�� �� ��ġ �� ����
            Quaternion desiredRotation = Quaternion.Euler(fixedRotationX, fixedRotationY, fixedRotationZ);
            Vector3 desiredPosition = target.position + offset + fixedPosition;

            // �ε巯�� �̵� �� ȸ��
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        }
    }
}

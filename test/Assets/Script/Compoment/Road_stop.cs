using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_stop : MonoBehaviour
{
    public GameObject roadPrefab; // road �������� ������ ����
    private int numberOfRoadsToCreate = 20; // ������ road ����

    // Start is called before the first frame update
    void Start()
    {
        // ���ϴ� ������ road �ν��Ͻ��� ������ �� �ֽ��ϴ�.
        CreateRoads(numberOfRoadsToCreate);
    }

    // Update is called once per frame
    void Update()
    {
        // �ʿ��� ��� ������Ʈ ������ �߰��� �� �ֽ��ϴ�.
    }

    // ������ ������ŭ road �ν��Ͻ��� �����ϴ� �޼���
    public void CreateRoads(int numberOfRoads)
    {
        for (int i = 0; i < numberOfRoads; i++)
        {
            GameObject newRoad = Instantiate(roadPrefab); // road �������� �����Ͽ� ���ο� �ν��Ͻ� ����
            float zPosition = i + 0.5f; // z �� ��ġ�� ���� �ε����� 0.5�� ���� ������ ���� (0.5, 1.5, 2.5, ..., 9.5)
            newRoad.transform.position = new Vector3(0, 0, zPosition); // road �ν��Ͻ��� ��ġ ����
        }
    }

}

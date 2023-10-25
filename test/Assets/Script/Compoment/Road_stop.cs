using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_stop : MonoBehaviour
{
    public GameObject roadPrefab; // road 프리팹을 저장할 변수
    private int numberOfRoadsToCreate = 20; // 생성할 road 개수

    // Start is called before the first frame update
    void Start()
    {
        // 원하는 시점에 road 인스턴스를 생성할 수 있습니다.
        CreateRoads(numberOfRoadsToCreate);
    }

    // Update is called once per frame
    void Update()
    {
        // 필요한 경우 업데이트 로직을 추가할 수 있습니다.
    }

    // 지정된 개수만큼 road 인스턴스를 생성하는 메서드
    public void CreateRoads(int numberOfRoads)
    {
        for (int i = 0; i < numberOfRoads; i++)
        {
            GameObject newRoad = Instantiate(roadPrefab); // road 프리팹을 복제하여 새로운 인스턴스 생성
            float zPosition = i + 0.5f; // z 축 위치를 현재 인덱스에 0.5를 더한 값으로 설정 (0.5, 1.5, 2.5, ..., 9.5)
            newRoad.transform.position = new Vector3(0, 0, zPosition); // road 인스턴스의 위치 설정
        }
    }

}

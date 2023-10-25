using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Grass; // Grass 프리팹을 연결해주세요.
    public GameObject Water; // Water 프리팹을 연결해주세요.
    public GameObject Road;  // Road 프리팹을 연결해주세요.

    public GameObject Car_1;


    int firstRand;
    int secondRand;
    //int disPlayer = 12;
    float disPlayer = 0.5f;

    Vector3 intPos = new Vector3(0, 0, 0);
    Vector3 car_leftPos = new Vector3(0, 0, 0);

    void Start()
    {
        // 초기에 5개의 인스턴스를 생성합니다.
        for (int i = 0; i < 15; i++)
        {
            firstRand = Random.Range(1, 4);
            //intPos = new Vector3(-5f, 0f, 0.5f); // 초기 위치 설정

            intPos = new Vector3(0, 0, disPlayer);
            car_leftPos = new Vector3( -15f, 0.05f, 0.5f);
            disPlayer += 1;


            // 잔디
            if (firstRand == 1)
            {
                GameObject GrassIns = Instantiate(Grass) as GameObject;
                GrassIns.transform.position = intPos;
            }

            // 도로
            else if (firstRand == 2)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // Road 인스턴스가 생성될 때 자동차 인스턴스를 생성합니다.
                GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                CarIns.transform.Translate(Vector3.forward * 5f); // 자동차를 오른쪽으로 이동
            }

            // 물
            else if (firstRand == 3)
            {
                GameObject WaterIns = Instantiate(Water) as GameObject;
                WaterIns.transform.position = intPos;
            }
        }
    }


    void Update()
    {
        if (Input.GetButtonDown("up"))
        {
            firstRand = Random.Range(1, 4);

            // firstRand의 값이 1~3 ( 1 == 잔디 , 2== 도로, 3 == 물 )
            // secondRand는 본인이 설정. 얼만큼 해당 그 인스턴스를 생성할건지.

            if(firstRand==1)
            {
                secondRand = Random.Range(1, 5);
                for (int i = 0; i < secondRand;i++)
                {
                    intPos = new Vector3(0, 0, disPlayer);
                    disPlayer += 1;
                    GameObject GrassIns = Instantiate(Grass) as GameObject;
                    GrassIns.transform.position = intPos;

                }
            }
            if (firstRand == 2)
            {
                secondRand = Random.Range(1, 5);
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, 0, disPlayer);
                    disPlayer += 1;
                    GameObject RoadIns = Instantiate(Road) as GameObject;
                    RoadIns.transform.position = intPos;


                    // Road 인스턴스가 생성될 때 자동차 인스턴스를 생성합니다.
                    GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                    //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                    CarIns.transform.Translate(Vector3.forward * 5f); // 자동차를 오른쪽으로 이동

                }
            }
            if (firstRand == 3)
            {
                secondRand = Random.Range(1, 5);
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, 0, disPlayer);
                    disPlayer += 1;
                    GameObject WaterIns = Instantiate(Water) as GameObject;
                    WaterIns.transform.position = intPos;

                }
            }
        }
    }

}
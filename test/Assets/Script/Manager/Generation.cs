using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Grass; // Grass �������� �������ּ���.
    public GameObject Water; // Water �������� �������ּ���.
    public GameObject Road;  // Road �������� �������ּ���.

    public GameObject Car_1;


    int firstRand;
    int secondRand;
    //int disPlayer = 12;
    float disPlayer = 0.5f;

    Vector3 intPos = new Vector3(0, 0, 0);
    Vector3 car_leftPos = new Vector3(0, 0, 0);

    void Start()
    {
        // �ʱ⿡ 5���� �ν��Ͻ��� �����մϴ�.
        for (int i = 0; i < 15; i++)
        {
            firstRand = Random.Range(1, 4);
            //intPos = new Vector3(-5f, 0f, 0.5f); // �ʱ� ��ġ ����

            intPos = new Vector3(0, 0, disPlayer);
            car_leftPos = new Vector3( -15f, 0.05f, 0.5f);
            disPlayer += 1;


            // �ܵ�
            if (firstRand == 1)
            {
                GameObject GrassIns = Instantiate(Grass) as GameObject;
                GrassIns.transform.position = intPos;
            }

            // ����
            else if (firstRand == 2)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // Road �ν��Ͻ��� ������ �� �ڵ��� �ν��Ͻ��� �����մϴ�.
                GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                CarIns.transform.Translate(Vector3.forward * 5f); // �ڵ����� ���������� �̵�
            }

            // ��
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

            // firstRand�� ���� 1~3 ( 1 == �ܵ� , 2== ����, 3 == �� )
            // secondRand�� ������ ����. ��ŭ �ش� �� �ν��Ͻ��� �����Ұ���.

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


                    // Road �ν��Ͻ��� ������ �� �ڵ��� �ν��Ͻ��� �����մϴ�.
                    GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                    //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                    CarIns.transform.Translate(Vector3.forward * 5f); // �ڵ����� ���������� �̵�

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
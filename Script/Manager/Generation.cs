/*using UnityEngine;
using System.Collections.Generic;

public class Generation : MonoBehaviour
{
    public GameObject Grass; // Grass �������� �������ּ���.
    public GameObject Water; // Water �������� �������ּ���.
    public GameObject Road;  // Road �������� �������ּ���.

    public GameObject Soccer_ball; // �౸�� ����


    // ������ ���� �����ϴ� ����Ʈ
    private List<GameObject> generatedPaths = new List<GameObject>();

    // ����ڰ� ������ ���� �����ϴ� ����Ʈ
    private List<GameObject> userPath = new List<GameObject>();

    public float deletionThreshold = -1f; // Adjust this threshold based on your scene and camera settings


    public float minSpeed = 2f; // Minimum speed for cars
    public float maxSpeed = 5f; // Maximum speed for cars

    public float runnerminSpeed = 4f;
    public float runnermaxSpeed = 7f;


    public GameObject Car_1;

    public GameObject soccer;

    public GameObject runner;

    public List<float> initialPosition_X = new List<float>();//int�����ϰ�
    public List<float> initialPosition_Y = new List<float>();//int�����ϰ�
    public List<float> initialPosition_Z = new List<float>();//int�����ϰ�

*//*    public Vector3 initialPosition_X;
    public Vector3 initialPosition_Y;
    public Vector3 initialPosition_Z;*//*


    int firstRand;
    int secondRand;
    int Soccer_ball_Rand;
    int first_tackleRand;
    int tackle_or_runner;
    //int disPlayer = 12;
    float disPlayer = 0.5f;

    Vector3 intPos = new Vector3(0, 0, 0);
    Vector3 car_leftPos = new Vector3(0, 0, 0);
    //Vector3 car_rightPos = new Vector3(13f, 1f, 0.5f);
    Vector3 car_rightPos = new Vector3(0, 0, 0);
    Vector3 runner_leftPos = new Vector3(0, 0, 0);
    Vector3 runner_rightPos = new Vector3(0, 0, 0);


    void Start()
    {


        // �ʱ⿡ 15���� �ν��Ͻ��� �����մϴ�.
        for (int i = 0; i < 15; i++)
        {
            // �� ���� �ڵ� �߰�
            GeneratePath();

            firstRand = Random.Range(1, 11);
            Soccer_ball_Rand = Random.Range(1, 11);


            //intPos = new Vector3(-5f, 0f, 0.5f); // �ʱ� ��ġ ����

            intPos = new Vector3(0, 0, disPlayer);

            car_leftPos = new Vector3(-15f, 0f, 0.5f);
            car_rightPos = new Vector3(13f, 1f, 0.5f);


            disPlayer += 1;


            // �ܵ�
            if (firstRand >= 1 && firstRand <= 4)
            {
                GameObject GrassIns = Instantiate(Grass) as GameObject;
                GrassIns.transform.position = intPos;


                //�౸�� ����
                if (Soccer_ball_Rand >= 1 && Soccer_ball_Rand <= 2)
                {
                    GameObject Soccer_ballIns = Instantiate(Soccer_ball) as GameObject;

                    // X ��ǥ�� -10���� 10 ������ ������ ������ ����
                    float randomX = Random.Range(-10f, 10f);
                    int randomXAsInt = (int)randomX;
                    // Y ��ǥ�� 0.3�� ���Ͽ� ��ü�� ���� ���� ��ġ�ϵ��� ����
                    GameObject soccerBallIns = Instantiate(Soccer_ball, new Vector3(randomXAsInt + 0.5f, 0.3f, -0.5f), Quaternion.identity) as GameObject;

                    Rigidbody soccerBallRigidbody = soccerBallIns.GetComponent<Rigidbody>();
                    soccerBallRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                }

            }

            // ����
            else if (firstRand >= 5 && firstRand <= 10)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // ��������, ��Ŭ���� ���� -> ���� �������� ������ �������� ���� -> ���ǵ� ����

                tackle_or_runner = Random.Range(1, 11);
                // 1~7 ��Ŭ
                // 8~10 ����


                if (tackle_or_runner >= 1 && tackle_or_runner <= 7)
                {
                    // ��Ŭ~
                    // ���� ��Ŭ, ������ ��Ŭ ����
                    first_tackleRand = Random.Range(1, 3);

                    if (first_tackleRand == 1)
                    {
                        // ��Ŭ ���� -> ������ ����

                        // Road �ν��Ͻ��� ������ �� �ڵ��� �ν��Ͻ��� �����մϴ�.
                        GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                        //CarIns.transform.Translate(Vector3.forward * 5f); // �ڵ����� ���������� �̵�
                        Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));

                        initialPosition_X.Add(car_leftPos.x);
                        initialPosition_Y.Add(car_leftPos.y);
                        initialPosition_Z.Add(car_leftPos.z);


                        // SetRandomSpeed(CarIns);
                    }

                    if (first_tackleRand == 2)
                    {
                        // ��Ŭ ������ -> ���� ����
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        //GameObject Carright = Instantiate(Car_1, car_rightPos, Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
                    }
                }
                else if (tackle_or_runner >= 8 && tackle_or_runner <= 10)
                {
                    // ����

                    first_tackleRand = Random.Range(1, 3);  // ���� ���ϱ� ����

                    if (first_tackleRand == 1)
                    {
                        // ��Ŭ ���� -> ������ ����

                        *//*                        // Road �ν��Ͻ��� ������ �� �ڵ��� �ν��Ͻ��� �����մϴ�.
                                                GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                                                //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                                                //CarIns.transform.Translate(Vector3.forward * 5f); // �ڵ����� ���������� �̵�
                                                Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                                                carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));*//*


                        GameObject runnerIns = Instantiate(runner, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        Car_Left carLefttScript = runnerIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));

                    }

                    if (first_tackleRand == 2)
                    {
                        // ���� ������ -> ���� ����
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));
                    }
                }


            }

        }
    }


    void Update()
    {
        // Ư�� ���ǿ��� �� ����
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeletePath();
        }


        if (Input.GetButtonDown("up"))
        {
            firstRand = Random.Range(1, 11);

            // firstRand�� ���� 1~3 ( 1 == �ܵ� , 2== ����, 3 == �� )
            // secondRand�� ������ ����. ��ŭ �ش� �� �ν��Ͻ��� �����Ұ���.

            // �ܵ�
            if (firstRand >= 1 && firstRand <= 4)
            {
                secondRand = Random.Range(1, 5);
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, 0, disPlayer);
                    disPlayer += 1;
                    GameObject GrassIns = Instantiate(Grass) as GameObject;
                    GrassIns.transform.position = intPos;

                }
            }
            //����
            else if (firstRand >= 5 && firstRand <= 10)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // ��������, ��Ŭ���� ���� -> ���� �������� ������ �������� ���� -> ���ǵ� ����

                tackle_or_runner = Random.Range(1, 11);
                // 1~7 ��Ŭ
                // 8~10 ����


                if (tackle_or_runner >= 1 && tackle_or_runner <= 7)
                {
                    // ��Ŭ~
                    // ���� ��Ŭ, ������ ��Ŭ ����
                    first_tackleRand = Random.Range(1, 3);

                    if (first_tackleRand == 1)
                    {
                        // ��Ŭ ���� -> ������ ����

                        // Road �ν��Ͻ��� ������ �� �ڵ��� �ν��Ͻ��� �����մϴ�.
                        GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                        //CarIns.transform.Translate(Vector3.forward * 5f); // �ڵ����� ���������� �̵�
                        Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));

                        // SetRandomSpeed(CarIns);
                    }

                    if (first_tackleRand == 2)
                    {
                        // ��Ŭ ������ -> ���� ����
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        //GameObject Carright = Instantiate(Car_1, car_rightPos, Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
                    }
                }
            }
            else if (tackle_or_runner >= 8 && tackle_or_runner <= 10)
            {
                // ����

                first_tackleRand = Random.Range(1, 3);  // ���� ���ϱ� ����

                if (first_tackleRand == 1)
                {
                    // ��Ŭ ���� -> ������ ����

                    GameObject runnerIns = Instantiate(runner, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                    Car_Left carLefttScript = runnerIns.AddComponent<Car_Left>();
                    carLefttScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));

                }

                if (first_tackleRand == 2)
                {
                    // ���� ������ -> ���� ����
                    GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                    Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                    carRightScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));
                }
            }

            // �� ���� �ڵ� �߰�
            GeneratePath();

            // ����ڰ� ������ �濡 ���� ���� �߰�
            userPath.Add(generatedPaths[generatedPaths.Count - 1]); // �ֱٿ� ������ ���� �߰�

        }
    }
    void SetRandomSpeed(GameObject car)
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Car_Left carMovement = car.GetComponent<Car_Left>();
        if (carMovement != null)
        {
            carMovement.SetSpeed(randomSpeed);
            Debug.Log("Set speed to: " + randomSpeed);
        }
        else
        {
            Debug.LogWarning("Car_Left component not found on the car GameObject.");
        }
    }

    void GeneratePath()
    {
        // �� ���� ������ Start()�� Update()���� �ߺ��ǹǷ� �̸� �ϳ��� �Լ��� �����Ͽ� ����
        // ... (���� �ڵ�)

        // ������ ���� ����Ʈ�� �߰�
        generatedPaths.Add(Road);
    }

    void DeletePath()
    {
        if (generatedPaths.Count > 0)
        {
            // ����Ʈ���� ���� ������ ���� �������� ����
            GameObject pathToDelete = generatedPaths[0];
            generatedPaths.RemoveAt(0);

            // ������ ���� ���� (Prefab �ν��Ͻ��� �ı�)
            DestroyImmediate(pathToDelete);

            // Prefab �ν��Ͻ��� ������ �Ŀ� ����Ʈ������ ����
            generatedPaths.Remove(pathToDelete);
        }
    }



}*/

using UnityEngine;
using System.Collections.Generic;

public class Generation : MonoBehaviour
{
    public GameObject Grass; // Grass �������� �������ּ���.
    public GameObject Water; // Water �������� �������ּ���.
    public GameObject Road;  // Road �������� �������ּ���.

    public GameObject Soccer_ball; // �౸�� ����


    // ������ ���� �����ϴ� ����Ʈ
    private List<GameObject> generatedPaths = new List<GameObject>();

    // ����ڰ� ������ ���� �����ϴ� ����Ʈ
    private List<GameObject> userPath = new List<GameObject>();

    public float deletionThreshold = -1f; // Adjust this threshold based on your scene and camera settings


    public float minSpeed = 2f; // Minimum speed for cars
    public float maxSpeed = 5f; // Maximum speed for cars

    public float runnerminSpeed = 4f;
    public float runnermaxSpeed = 7f;


    public GameObject Car_1;

    public GameObject soccer;

    public GameObject runner;



    int firstRand;
    int secondRand;
    int Soccer_ball_Rand;
    int first_tackleRand;
    int tackle_or_runner;
    //int disPlayer = 12;
    float disPlayer = 0.5f;

    Vector3 intPos = new Vector3(0, 0, 0);
    Vector3 car_leftPos = new Vector3(0, 0, 0);
    //Vector3 car_rightPos = new Vector3(13f, 1f, 0.5f);
    Vector3 car_rightPos = new Vector3(0, 0, 0);
    Vector3 runner_leftPos = new Vector3(0, 0, 0);
    Vector3 runner_rightPos = new Vector3(0, 0, 0);


    void Start()
    {
        // �ʱ⿡ 15���� �ν��Ͻ��� �����մϴ�.
        for (int i = 0; i < 15; i++)
        {
            // �� ���� �ڵ� �߰�
            GeneratePath();

            firstRand = Random.Range(1, 11);
            Soccer_ball_Rand = Random.Range(1, 11);


            //intPos = new Vector3(-5f, 0f, 0.5f); // �ʱ� ��ġ ����

            intPos = new Vector3(0, 0, disPlayer);

            car_leftPos = new Vector3(-15f, 0f, 0.5f);
            car_rightPos = new Vector3(13f, 1f, 0.5f);


            disPlayer += 1;


            // �ܵ�
            if (firstRand >= 1 && firstRand <= 4)
            {
                GameObject GrassIns = Instantiate(Grass) as GameObject;
                GrassIns.transform.position = intPos;


                //�౸�� ����
                if (Soccer_ball_Rand >= 1 && Soccer_ball_Rand <= 2)
                {
                    GameObject Soccer_ballIns = Instantiate(Soccer_ball) as GameObject;

                    // X ��ǥ�� -10���� 10 ������ ������ ������ ����
                    float randomX = Random.Range(-10f, 10f);
                    int randomXAsInt = (int)randomX;
                    // Y ��ǥ�� 0.3�� ���Ͽ� ��ü�� ���� ���� ��ġ�ϵ��� ����
                    GameObject soccerBallIns = Instantiate(Soccer_ball, new Vector3(randomXAsInt + 0.5f, 0.3f, -0.5f), Quaternion.identity) as GameObject;

                    Rigidbody soccerBallRigidbody = soccerBallIns.GetComponent<Rigidbody>();
                    soccerBallRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                }

            }

            // ����
            else if (firstRand >= 5 && firstRand <= 10)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // ��������, ��Ŭ���� ���� -> ���� �������� ������ �������� ���� -> ���ǵ� ����

                tackle_or_runner = Random.Range(1, 11);
                // 1~7 ��Ŭ
                // 8~10 ����


                if (tackle_or_runner >= 1 && tackle_or_runner <= 7)
                {
                    // ��Ŭ~
                    // ���� ��Ŭ, ������ ��Ŭ ����
                    first_tackleRand = Random.Range(1, 3);

                    if (first_tackleRand == 1)
                    {
                        // ��Ŭ ���� -> ������ ����

                        // Road �ν��Ͻ��� ������ �� �ڵ��� �ν��Ͻ��� �����մϴ�.
                        GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                        //CarIns.transform.Translate(Vector3.forward * 5f); // �ڵ����� ���������� �̵�
                        Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));

                        // SetRandomSpeed(CarIns);
                    }

                    if (first_tackleRand == 2)
                    {
                        // ��Ŭ ������ -> ���� ����
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        //GameObject Carright = Instantiate(Car_1, car_rightPos, Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
                    }
                }
                else if (tackle_or_runner >= 8 && tackle_or_runner <= 10)
                {
                    // ����

                    first_tackleRand = Random.Range(1, 3);  // ���� ���ϱ� ����

                    if (first_tackleRand == 1)
                    {
                        // ��Ŭ ���� -> ������ ����

                        /*                        // Road �ν��Ͻ��� ������ �� �ڵ��� �ν��Ͻ��� �����մϴ�.
                                                GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                                                //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                                                //CarIns.transform.Translate(Vector3.forward * 5f); // �ڵ����� ���������� �̵�
                                                Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                                                carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));*/


                        GameObject runnerIns = Instantiate(runner, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        Car_Left carLefttScript = runnerIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));

                    }

                    if (first_tackleRand == 2)
                    {
                        // ���� ������ -> ���� ����
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));
                    }
                }


            }

        }
    }


    void Update()
    {
        // Ư�� ���ǿ��� �� ����
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeletePath();
        }


        if (Input.GetButtonDown("up"))
        {
            firstRand = Random.Range(1, 11);

            // firstRand�� ���� 1~3 ( 1 == �ܵ� , 2== ����, 3 == �� )
            // secondRand�� ������ ����. ��ŭ �ش� �� �ν��Ͻ��� �����Ұ���.

            // �ܵ�
            if (firstRand >= 1 && firstRand <= 4)
            {
                secondRand = Random.Range(1, 5);
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, 0, disPlayer);
                    disPlayer += 1;
                    GameObject GrassIns = Instantiate(Grass) as GameObject;
                    GrassIns.transform.position = intPos;

                }
            }
            //����
            else if (firstRand >= 5 && firstRand <= 10)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // ��������, ��Ŭ���� ���� -> ���� �������� ������ �������� ���� -> ���ǵ� ����

                tackle_or_runner = Random.Range(1, 11);
                // 1~7 ��Ŭ
                // 8~10 ����


                if (tackle_or_runner >= 1 && tackle_or_runner <= 7)
                {
                    // ��Ŭ~
                    // ���� ��Ŭ, ������ ��Ŭ ����
                    first_tackleRand = Random.Range(1, 3);

                    if (first_tackleRand == 1)
                    {
                        // ��Ŭ ���� -> ������ ����

                        // Road �ν��Ͻ��� ������ �� �ڵ��� �ν��Ͻ��� �����մϴ�.
                        GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                        //CarIns.transform.Translate(Vector3.forward * 5f); // �ڵ����� ���������� �̵�
                        Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));

                        // SetRandomSpeed(CarIns);
                    }

                    if (first_tackleRand == 2)
                    {
                        // ��Ŭ ������ -> ���� ����
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        //GameObject Carright = Instantiate(Car_1, car_rightPos, Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
                    }
                }
            }
            else if (tackle_or_runner >= 8 && tackle_or_runner <= 10)
            {
                // ����

                first_tackleRand = Random.Range(1, 3);  // ���� ���ϱ� ����

                if (first_tackleRand == 1)
                {
                    // ��Ŭ ���� -> ������ ����

                    GameObject runnerIns = Instantiate(runner, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                    Car_Left carLefttScript = runnerIns.AddComponent<Car_Left>();
                    carLefttScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));

                }

                if (first_tackleRand == 2)
                {
                    // ���� ������ -> ���� ����
                    GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                    Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                    carRightScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));
                }
            }

            // �� ���� �ڵ� �߰�
            GeneratePath();

            // ����ڰ� ������ �濡 ���� ���� �߰�
            userPath.Add(generatedPaths[generatedPaths.Count - 1]); // �ֱٿ� ������ ���� �߰�

        }
    }
    void SetRandomSpeed(GameObject car)
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Car_Left carMovement = car.GetComponent<Car_Left>();
        if (carMovement != null)
        {
            carMovement.SetSpeed(randomSpeed);
            Debug.Log("Set speed to: " + randomSpeed);
        }
        else
        {
            Debug.LogWarning("Car_Left component not found on the car GameObject.");
        }
    }

    void GeneratePath()
    {
        // �� ���� ������ Start()�� Update()���� �ߺ��ǹǷ� �̸� �ϳ��� �Լ��� �����Ͽ� ����
        // ... (���� �ڵ�)

        // ������ ���� ����Ʈ�� �߰�
        generatedPaths.Add(Road);
    }

    void DeletePath()
    {
        if (generatedPaths.Count > 0)
        {
            // ����Ʈ���� ���� ������ ���� �������� ����
            GameObject pathToDelete = generatedPaths[0];
            generatedPaths.RemoveAt(0);

            // ������ ���� ���� (Prefab �ν��Ͻ��� �ı�)
            DestroyImmediate(pathToDelete);

            // Prefab �ν��Ͻ��� ������ �Ŀ� ����Ʈ������ ����
            generatedPaths.Remove(pathToDelete);
        }
    }



}
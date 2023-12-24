/*using UnityEngine;
using System.Collections.Generic;

public class Generation : MonoBehaviour
{
    public GameObject Grass; // Grass 프리팹을 연결해주세요.
    public GameObject Water; // Water 프리팹을 연결해주세요.
    public GameObject Road;  // Road 프리팹을 연결해주세요.

    public GameObject Soccer_ball; // 축구공 연결


    // 생성된 길을 저장하는 리스트
    private List<GameObject> generatedPaths = new List<GameObject>();

    // 사용자가 지나온 길을 저장하는 리스트
    private List<GameObject> userPath = new List<GameObject>();

    public float deletionThreshold = -1f; // Adjust this threshold based on your scene and camera settings


    public float minSpeed = 2f; // Minimum speed for cars
    public float maxSpeed = 5f; // Maximum speed for cars

    public float runnerminSpeed = 4f;
    public float runnermaxSpeed = 7f;


    public GameObject Car_1;

    public GameObject soccer;

    public GameObject runner;

    public List<float> initialPosition_X = new List<float>();//int들어가야하고
    public List<float> initialPosition_Y = new List<float>();//int들어가야하고
    public List<float> initialPosition_Z = new List<float>();//int들어가야하고

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


        // 초기에 15개의 인스턴스를 생성합니다.
        for (int i = 0; i < 15; i++)
        {
            // 길 생성 코드 추가
            GeneratePath();

            firstRand = Random.Range(1, 11);
            Soccer_ball_Rand = Random.Range(1, 11);


            //intPos = new Vector3(-5f, 0f, 0.5f); // 초기 위치 설정

            intPos = new Vector3(0, 0, disPlayer);

            car_leftPos = new Vector3(-15f, 0f, 0.5f);
            car_rightPos = new Vector3(13f, 1f, 0.5f);


            disPlayer += 1;


            // 잔디
            if (firstRand >= 1 && firstRand <= 4)
            {
                GameObject GrassIns = Instantiate(Grass) as GameObject;
                GrassIns.transform.position = intPos;


                //축구공 생성
                if (Soccer_ball_Rand >= 1 && Soccer_ball_Rand <= 2)
                {
                    GameObject Soccer_ballIns = Instantiate(Soccer_ball) as GameObject;

                    // X 좌표를 -10에서 10 사이의 랜덤한 값으로 설정
                    float randomX = Random.Range(-10f, 10f);
                    int randomXAsInt = (int)randomX;
                    // Y 좌표에 0.3을 더하여 물체가 지면 위에 위치하도록 조정
                    GameObject soccerBallIns = Instantiate(Soccer_ball, new Vector3(randomXAsInt + 0.5f, 0.3f, -0.5f), Quaternion.identity) as GameObject;

                    Rigidbody soccerBallRigidbody = soccerBallIns.GetComponent<Rigidbody>();
                    soccerBallRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                }

            }

            // 도로
            else if (firstRand >= 5 && firstRand <= 10)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // 러너인지, 태클인지 랜덤 -> 왼쪽 방향인지 오른쪽 방향인지 랜덤 -> 스피드 랜덤

                tackle_or_runner = Random.Range(1, 11);
                // 1~7 태클
                // 8~10 러너


                if (tackle_or_runner >= 1 && tackle_or_runner <= 7)
                {
                    // 태클~
                    // 왼쪽 태클, 오른쪽 태클 랜덤
                    first_tackleRand = Random.Range(1, 3);

                    if (first_tackleRand == 1)
                    {
                        // 태클 왼쪽 -> 오른쪽 방향

                        // Road 인스턴스가 생성될 때 자동차 인스턴스를 생성합니다.
                        GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                        //CarIns.transform.Translate(Vector3.forward * 5f); // 자동차를 오른쪽으로 이동
                        Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));

                        initialPosition_X.Add(car_leftPos.x);
                        initialPosition_Y.Add(car_leftPos.y);
                        initialPosition_Z.Add(car_leftPos.z);


                        // SetRandomSpeed(CarIns);
                    }

                    if (first_tackleRand == 2)
                    {
                        // 태클 오른쪽 -> 왼쪽 방향
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        //GameObject Carright = Instantiate(Car_1, car_rightPos, Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
                    }
                }
                else if (tackle_or_runner >= 8 && tackle_or_runner <= 10)
                {
                    // 러너

                    first_tackleRand = Random.Range(1, 3);  // 방향 정하기 랜덤

                    if (first_tackleRand == 1)
                    {
                        // 태클 왼쪽 -> 오른쪽 방향

                        *//*                        // Road 인스턴스가 생성될 때 자동차 인스턴스를 생성합니다.
                                                GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                                                //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                                                //CarIns.transform.Translate(Vector3.forward * 5f); // 자동차를 오른쪽으로 이동
                                                Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                                                carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));*//*


                        GameObject runnerIns = Instantiate(runner, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        Car_Left carLefttScript = runnerIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));

                    }

                    if (first_tackleRand == 2)
                    {
                        // 러너 오른쪽 -> 왼쪽 방향
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
        // 특정 조건에서 길 삭제
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeletePath();
        }


        if (Input.GetButtonDown("up"))
        {
            firstRand = Random.Range(1, 11);

            // firstRand의 값이 1~3 ( 1 == 잔디 , 2== 도로, 3 == 물 )
            // secondRand는 본인이 설정. 얼만큼 해당 그 인스턴스를 생성할건지.

            // 잔디
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
            //도로
            else if (firstRand >= 5 && firstRand <= 10)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // 러너인지, 태클인지 랜덤 -> 왼쪽 방향인지 오른쪽 방향인지 랜덤 -> 스피드 랜덤

                tackle_or_runner = Random.Range(1, 11);
                // 1~7 태클
                // 8~10 러너


                if (tackle_or_runner >= 1 && tackle_or_runner <= 7)
                {
                    // 태클~
                    // 왼쪽 태클, 오른쪽 태클 랜덤
                    first_tackleRand = Random.Range(1, 3);

                    if (first_tackleRand == 1)
                    {
                        // 태클 왼쪽 -> 오른쪽 방향

                        // Road 인스턴스가 생성될 때 자동차 인스턴스를 생성합니다.
                        GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                        //CarIns.transform.Translate(Vector3.forward * 5f); // 자동차를 오른쪽으로 이동
                        Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));

                        // SetRandomSpeed(CarIns);
                    }

                    if (first_tackleRand == 2)
                    {
                        // 태클 오른쪽 -> 왼쪽 방향
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        //GameObject Carright = Instantiate(Car_1, car_rightPos, Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
                    }
                }
            }
            else if (tackle_or_runner >= 8 && tackle_or_runner <= 10)
            {
                // 러너

                first_tackleRand = Random.Range(1, 3);  // 방향 정하기 랜덤

                if (first_tackleRand == 1)
                {
                    // 태클 왼쪽 -> 오른쪽 방향

                    GameObject runnerIns = Instantiate(runner, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                    Car_Left carLefttScript = runnerIns.AddComponent<Car_Left>();
                    carLefttScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));

                }

                if (first_tackleRand == 2)
                {
                    // 러너 오른쪽 -> 왼쪽 방향
                    GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                    Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                    carRightScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));
                }
            }

            // 길 생성 코드 추가
            GeneratePath();

            // 사용자가 지나온 길에 현재 길을 추가
            userPath.Add(generatedPaths[generatedPaths.Count - 1]); // 최근에 생성된 길을 추가

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
        // 길 생성 로직은 Start()와 Update()에서 중복되므로 이를 하나의 함수로 추출하여 재사용
        // ... (기존 코드)

        // 생성된 길을 리스트에 추가
        generatedPaths.Add(Road);
    }

    void DeletePath()
    {
        if (generatedPaths.Count > 0)
        {
            // 리스트에서 가장 오래된 길을 가져오고 제거
            GameObject pathToDelete = generatedPaths[0];
            generatedPaths.RemoveAt(0);

            // 생성된 길을 삭제 (Prefab 인스턴스를 파괴)
            DestroyImmediate(pathToDelete);

            // Prefab 인스턴스가 삭제된 후에 리스트에서도 제거
            generatedPaths.Remove(pathToDelete);
        }
    }



}*/

using UnityEngine;
using System.Collections.Generic;

public class Generation : MonoBehaviour
{
    public GameObject Grass; // Grass 프리팹을 연결해주세요.
    public GameObject Water; // Water 프리팹을 연결해주세요.
    public GameObject Road;  // Road 프리팹을 연결해주세요.

    public GameObject Soccer_ball; // 축구공 연결


    // 생성된 길을 저장하는 리스트
    private List<GameObject> generatedPaths = new List<GameObject>();

    // 사용자가 지나온 길을 저장하는 리스트
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
        // 초기에 15개의 인스턴스를 생성합니다.
        for (int i = 0; i < 15; i++)
        {
            // 길 생성 코드 추가
            GeneratePath();

            firstRand = Random.Range(1, 11);
            Soccer_ball_Rand = Random.Range(1, 11);


            //intPos = new Vector3(-5f, 0f, 0.5f); // 초기 위치 설정

            intPos = new Vector3(0, 0, disPlayer);

            car_leftPos = new Vector3(-15f, 0f, 0.5f);
            car_rightPos = new Vector3(13f, 1f, 0.5f);


            disPlayer += 1;


            // 잔디
            if (firstRand >= 1 && firstRand <= 4)
            {
                GameObject GrassIns = Instantiate(Grass) as GameObject;
                GrassIns.transform.position = intPos;


                //축구공 생성
                if (Soccer_ball_Rand >= 1 && Soccer_ball_Rand <= 2)
                {
                    GameObject Soccer_ballIns = Instantiate(Soccer_ball) as GameObject;

                    // X 좌표를 -10에서 10 사이의 랜덤한 값으로 설정
                    float randomX = Random.Range(-10f, 10f);
                    int randomXAsInt = (int)randomX;
                    // Y 좌표에 0.3을 더하여 물체가 지면 위에 위치하도록 조정
                    GameObject soccerBallIns = Instantiate(Soccer_ball, new Vector3(randomXAsInt + 0.5f, 0.3f, -0.5f), Quaternion.identity) as GameObject;

                    Rigidbody soccerBallRigidbody = soccerBallIns.GetComponent<Rigidbody>();
                    soccerBallRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                }

            }

            // 도로
            else if (firstRand >= 5 && firstRand <= 10)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // 러너인지, 태클인지 랜덤 -> 왼쪽 방향인지 오른쪽 방향인지 랜덤 -> 스피드 랜덤

                tackle_or_runner = Random.Range(1, 11);
                // 1~7 태클
                // 8~10 러너


                if (tackle_or_runner >= 1 && tackle_or_runner <= 7)
                {
                    // 태클~
                    // 왼쪽 태클, 오른쪽 태클 랜덤
                    first_tackleRand = Random.Range(1, 3);

                    if (first_tackleRand == 1)
                    {
                        // 태클 왼쪽 -> 오른쪽 방향

                        // Road 인스턴스가 생성될 때 자동차 인스턴스를 생성합니다.
                        GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                        //CarIns.transform.Translate(Vector3.forward * 5f); // 자동차를 오른쪽으로 이동
                        Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));

                        // SetRandomSpeed(CarIns);
                    }

                    if (first_tackleRand == 2)
                    {
                        // 태클 오른쪽 -> 왼쪽 방향
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        //GameObject Carright = Instantiate(Car_1, car_rightPos, Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
                    }
                }
                else if (tackle_or_runner >= 8 && tackle_or_runner <= 10)
                {
                    // 러너

                    first_tackleRand = Random.Range(1, 3);  // 방향 정하기 랜덤

                    if (first_tackleRand == 1)
                    {
                        // 태클 왼쪽 -> 오른쪽 방향

                        /*                        // Road 인스턴스가 생성될 때 자동차 인스턴스를 생성합니다.
                                                GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                                                //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                                                //CarIns.transform.Translate(Vector3.forward * 5f); // 자동차를 오른쪽으로 이동
                                                Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                                                carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));*/


                        GameObject runnerIns = Instantiate(runner, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        Car_Left carLefttScript = runnerIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));

                    }

                    if (first_tackleRand == 2)
                    {
                        // 러너 오른쪽 -> 왼쪽 방향
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
        // 특정 조건에서 길 삭제
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeletePath();
        }


        if (Input.GetButtonDown("up"))
        {
            firstRand = Random.Range(1, 11);

            // firstRand의 값이 1~3 ( 1 == 잔디 , 2== 도로, 3 == 물 )
            // secondRand는 본인이 설정. 얼만큼 해당 그 인스턴스를 생성할건지.

            // 잔디
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
            //도로
            else if (firstRand >= 5 && firstRand <= 10)
            {
                GameObject RoadIns = Instantiate(Road) as GameObject;
                RoadIns.transform.position = intPos;

                // 러너인지, 태클인지 랜덤 -> 왼쪽 방향인지 오른쪽 방향인지 랜덤 -> 스피드 랜덤

                tackle_or_runner = Random.Range(1, 11);
                // 1~7 태클
                // 8~10 러너


                if (tackle_or_runner >= 1 && tackle_or_runner <= 7)
                {
                    // 태클~
                    // 왼쪽 태클, 오른쪽 태클 랜덤
                    first_tackleRand = Random.Range(1, 3);

                    if (first_tackleRand == 1)
                    {
                        // 태클 왼쪽 -> 오른쪽 방향

                        // Road 인스턴스가 생성될 때 자동차 인스턴스를 생성합니다.
                        GameObject CarIns = Instantiate(Car_1, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                        //CarIns.transform.position = new Vector3(-5f, car_leftPos.y, intPos.z);
                        //CarIns.transform.Translate(Vector3.forward * 5f); // 자동차를 오른쪽으로 이동
                        Car_Left carLefttScript = CarIns.AddComponent<Car_Left>();
                        carLefttScript.SetSpeed(Random.Range(minSpeed, maxSpeed));

                        // SetRandomSpeed(CarIns);
                    }

                    if (first_tackleRand == 2)
                    {
                        // 태클 오른쪽 -> 왼쪽 방향
                        GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        //GameObject Carright = Instantiate(Car_1, car_rightPos, Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                        Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                        carRightScript.SetSpeed(Random.Range(minSpeed, maxSpeed));
                    }
                }
            }
            else if (tackle_or_runner >= 8 && tackle_or_runner <= 10)
            {
                // 러너

                first_tackleRand = Random.Range(1, 3);  // 방향 정하기 랜덤

                if (first_tackleRand == 1)
                {
                    // 태클 왼쪽 -> 오른쪽 방향

                    GameObject runnerIns = Instantiate(runner, new Vector3(car_leftPos.x, car_leftPos.y, intPos.z), Quaternion.Euler(0f, 90f, 0f)) as GameObject;
                    Car_Left carLefttScript = runnerIns.AddComponent<Car_Left>();
                    carLefttScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));

                }

                if (first_tackleRand == 2)
                {
                    // 러너 오른쪽 -> 왼쪽 방향
                    GameObject Carright = Instantiate(Car_1, new Vector3(car_rightPos.x, car_rightPos.y, intPos.z), Quaternion.Euler(0f, -90f, 180f)) as GameObject;
                    Car_Right carRightScript = Carright.AddComponent<Car_Right>();
                    carRightScript.SetSpeed(Random.Range(runnerminSpeed, runnermaxSpeed));
                }
            }

            // 길 생성 코드 추가
            GeneratePath();

            // 사용자가 지나온 길에 현재 길을 추가
            userPath.Add(generatedPaths[generatedPaths.Count - 1]); // 최근에 생성된 길을 추가

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
        // 길 생성 로직은 Start()와 Update()에서 중복되므로 이를 하나의 함수로 추출하여 재사용
        // ... (기존 코드)

        // 생성된 길을 리스트에 추가
        generatedPaths.Add(Road);
    }

    void DeletePath()
    {
        if (generatedPaths.Count > 0)
        {
            // 리스트에서 가장 오래된 길을 가져오고 제거
            GameObject pathToDelete = generatedPaths[0];
            generatedPaths.RemoveAt(0);

            // 생성된 길을 삭제 (Prefab 인스턴스를 파괴)
            DestroyImmediate(pathToDelete);

            // Prefab 인스턴스가 삭제된 후에 리스트에서도 제거
            generatedPaths.Remove(pathToDelete);
        }
    }



}
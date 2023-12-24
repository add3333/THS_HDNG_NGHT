using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float speed;

    void Update()
    {
        if (transform.position.x < 15f)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
            SpawnNewCar();
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void SpawnNewCar()
    {
        Vector3 spawnPosition = new Vector3(-15f, 0f, 15f);
        GameObject CarIns = Instantiate(gameObject, spawnPosition, Quaternion.Euler(0f, 90f, 0f)) as GameObject;
        CarMovement carMovement = CarIns.GetComponent<CarMovement>();
        carMovement.SetSpeed(Random.Range(2f, 5f));
    }
}

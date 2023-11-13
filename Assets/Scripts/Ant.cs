using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public float forwardSpeed; // Prêdkoœæ poruszania siê do przodu.
    public float rotationSpeed; // Prêdkoœæ obrotu.
    public float nextRandomDirTime; //czas do nastêpnej zmiany kierunku
    public float randomMaxDuration;
    public float rotation;
    public Vector3 currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        forwardSpeed = 25f;
        rotationSpeed = 100f;
        nextRandomDirTime = 3f;
        randomMaxDuration = 3f;
        rotation = Random.Range(-rotationSpeed, rotationSpeed);
        currentDirection = transform.forward;
        RandomSpawn(380, 210);
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Check if it is time to find a new direction
        if (Time.time > nextRandomDirTime)
        {
            nextRandomDirTime = Time.time + Random.Range(randomMaxDuration / 3, randomMaxDuration);
            rotation = Random.Range(-rotationSpeed, rotationSpeed);
        }

        // Apply rotation
        transform.Rotate(Vector3.up * rotation * Time.deltaTime);

        currentDirection = transform.forward;

        // Go forward
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
    void RandomSpawn(float width, float height)
    {
        Vector3 minPosition = new Vector3(-width, 0f, -height);
        Vector3 maxPosition = new Vector3(width, 0f, height);

        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomZ = Random.Range(minPosition.z, maxPosition.z);

        transform.position = new Vector3(randomX, 0, randomZ);
    }

}

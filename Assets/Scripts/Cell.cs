using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Cell : MonoBehaviour
{
    public float stepSize; // Prêdkoœæ poruszania siê do przodu.
    public Vector3 stepDirection;
    public float nextStepTime; // Czas do nastêpnego kroku
    public float stepDuration;
    public float stepTime;


    Vector3 randomDirection;

    void Start()
    {
        stepSize = Random.Range(8f, 15f);
        nextStepTime = Random.Range(0.3f, 0.6f);
        stepTime = Random.Range(0.6f, 1.2f);

        //jeœli chcesz ¿eby chodzi³y w losowe kierunki
        //randomDirection = GetRandomStepDirection();
        //stepDirection = randomDirection * stepSize;

        //chodzenie tylko do przodu
        stepDirection = Vector3.forward * stepSize;
        stepDuration = Random.Range(0.3f, 0.6f); // jak szybkie bêdzie robiæ kroki

        RandomSpawn(380, 210);
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Check if it is time to find a new direction
        if (Time.time > nextStepTime)
        {
            nextStepTime = Time.time + stepTime;
            MakeStep();
        }
    }

    void MakeStep()
    {
        //randomDirection = GetRandomStepDirection();
        //stepDirection = randomDirection * stepSize;
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + stepDirection;

        float elapsedTime = 0f;

        while (elapsedTime < stepDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / stepDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
    }

    void RandomSpawn(float width, float height)
    {
        Vector3 minPosition = new Vector3(-width, 0f, -height);
        Vector3 maxPosition = new Vector3(width, 0f, height);

        float randomX = Random.Range(minPosition.x, maxPosition.x);
        float randomZ = Random.Range(minPosition.z, maxPosition.z);

        transform.position = new Vector3(randomX, 0, randomZ);
    }
    Vector3 GetRandomStepDirection()
    {
        float stepX = Random.Range(-1f, 1f);
        float stepZ = Random.Range(-1f, 1f);

        return new Vector3(stepX, 0, stepZ);
    }
}

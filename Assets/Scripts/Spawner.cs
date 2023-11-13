using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject objectToSpawn;
    
    public int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            Instantiate(objectToSpawn, Vector3.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

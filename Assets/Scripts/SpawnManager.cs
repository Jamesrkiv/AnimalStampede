using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRangeX = 20;
    private float[] spawnPosZ = new float[2]; // Spawn positions on z-axis
    private float[] spawnPosX = new float[2]; // Spawn positions on x-axis
    
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    public GameObject[] animalPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosZ[0] = -5;
        spawnPosZ[1] = 20;
        spawnPosX[0] = -22;
        spawnPosX[1] = 22;

        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        /* For testing
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
        */
    }

    void SpawnRandomAnimal()
    {
        if (Random.Range(0, 2) > 0) // Decides whether animal spawns from top/bottom or sides of screen
        {
            float zPos = spawnPosZ[Random.Range(0, 2)];
            Quaternion rotation = new Quaternion();

            if (zPos == spawnPosZ[0]) rotation = Quaternion.Euler(0f, 0f, 0f); // Corrects rotation of animal
            else rotation = Quaternion.Euler(0f, 180f, 0f);

            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, zPos);
            Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);
        }
        else
        {
            float xPos = spawnPosX[Random.Range(0, 2)]; 
            Quaternion rotation = new Quaternion();

            if (xPos == spawnPosX[0]) rotation = Quaternion.Euler(0f, 90f, 0f); // Corrects rotation of animal
            else rotation = Quaternion.Euler(0f, 270f, 0f);

            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnPos = new Vector3(xPos, 0, Random.Range(-1, 15));
            Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{

    public float spawnRangeX = 15;
    public float spawnPosZ = 15;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void spawnFood()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(0, spawnPosZ));
        Instantiate(gameObject, spawnPos, gameObject.transform.rotation);
    }


    /*public void OnColliderEnter(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            Debug.Log("Food!");
            Destroy(other.gameObject);
            spawnFood();
            Debug.Log("Food!");
        }
    }*/

    void OnTriggerEnter(Collider col)
    {
        spawnFood();
        Debug.Log("Food!");
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    private float rightBound = 25;
    private float leftBound = -25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound) // Deltes things that go off the top or bottom of the screen
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < leftBound || transform.position.x > rightBound) // Deletes things that go off the sides of the screen
        {
            Destroy(gameObject);
        }
    }
}

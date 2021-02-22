using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 20.0f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.x < -xRange) // If player is out of bounds to the left, put them back in-bounds
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange) // If player is out of bounds to the right, put them back in-bounds
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Looks for spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch projectile from player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
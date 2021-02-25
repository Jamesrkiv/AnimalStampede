using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    private float verticalInput;
    private float rotationInput;
    public float rotationSpeed = 50.0f;
    public float moveSpeed = 10.0f;

    public float xRange = 20.0f;
    public float zRangeUpper = 16.0f;
    public float zRangeLower = -1.0f;

    public GameObject projectilePrefab;

    private string animationState = "Animation_int";
    private Animator animator;

    private bool dead = false;
    private bool win = false;

    public float score = 0;
    public float pointsPer = 100;
    public float winPoints = 300;

    enum CharStates
    {
        idle = 20,
        walk = 30,
        death = 50,
        dance = 100
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        if (transform.position.x < -xRange) // If player is out of bounds to the left, put them back in-bounds
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange) // If player is out of bounds to the right, put them back in-bounds
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < zRangeLower)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeLower);
        }
        else if (transform.position.z > zRangeUpper)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeUpper);
        }

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * moveSpeed);
        transform.Rotate(0, rotationInput * rotationSpeed * Time.deltaTime, 0);

        if (!dead && !win) UpdateState();

        // Looks for spacebar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch projectile from player
            if (!dead) Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
    private void UpdateState()
    {
        // Changes to walking animation if character is moving
        if (verticalInput != 0) animator.SetInteger(animationState, (int)CharStates.walk);
        
        // Changes to idle if character isn't moving
        else animator.SetInteger(animationState, (int)CharStates.idle);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "animal" && !win)
        {
            dead = true;
            rotationSpeed = 0f;
            moveSpeed = 0f;
            animator.SetInteger(animationState, (int)CharStates.death);
        }
        
        else if (other.tag == "food")
        {
            score += pointsPer;
            Debug.Log(score);
            if (score == winPoints)
            {
                win = true;
                rotationSpeed = 0f;
                moveSpeed = 0f;
                animator.SetInteger(animationState, (int)CharStates.dance);
            }
                
        }
        
    }
}
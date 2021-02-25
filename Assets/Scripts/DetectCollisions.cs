using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DetectCollisions : MonoBehaviour
{

    public Text gameOver;
    public GameObject playerController;
    public Button restartButton;
    public Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "animal")
        {
            gameOver.text = "Game Over";
            // playerController.GetComponent<PlayerController>().enabled = false;
            // Functionality moved to PlayerController.cs to get animation transitions working
            restartButton.gameObject.SetActive(true);
            closeButton.gameObject.SetActive(true);

        }
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{

    public Text gameOver;
    public Text objective;
    public GameObject playerController;
    public Button restartButton;
    public Button closeButton;
    public GameObject scoreObject;

    public float score = 0;
    public float winPoints = 300;
    public float pointsPer = 100;
   

    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        objective.text = "Score to reach:" + winPoints;
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
        else if (other.tag == "food")
        {
            score += pointsPer;
            scoreObject.GetComponent<Text>().text = score.ToString("F0");
            Debug.Log(score);
            if (score == winPoints)
            {
                gameOver.text = "You Win!";
                objective.gameObject.SetActive(false);
                restartButton.gameObject.SetActive(true);
                closeButton.gameObject.SetActive(true);
            }
        }
        
    }

    
}

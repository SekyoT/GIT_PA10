using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;

    public Text gameover;
    public Text Restart;

    public Text score;

    public int Score = 0;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rb = GetComponent<Rigidbody>();
        gameover.enabled = false;
        Restart.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = new Vector3(0, 4, 0); 
            
        }

        if (Restart.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SceneManager.LoadScene(0);
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            gameover.enabled = true;
            Restart.enabled = true;                    
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            Score += 1;
            score.text = "SCORE : " + Score;
        }
    }
}

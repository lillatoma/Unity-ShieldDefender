using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        //We add a GameManager object to manipulate player score

        gameManager = GameObject.FindObjectOfType<GameManager>();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //2 extra points if a good object hits the body
        //Game loss if a bad object hits the body
        if (collision.tag == "GoodObject")
            gameManager.AddScore(2);
        else if (collision.tag == "BadObject")
            gameManager.ResetGame();
        else return; //Any other collision is allowed

        //Remove the unnecessary game object
        Destroy(collision.gameObject);


    }
}

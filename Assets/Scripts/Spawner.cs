using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject badObject;
    public GameObject goodObject;

    public float goodPercentage; //Supposed to be between 0 and 1
    public float objectSpeed;

    private GameManager gameManager;
    private float timeLeftTillNextSpawn = 1f;


    void SpawnObject()
    {
        int r = Random.Range(0, 1000); //Random number to decide whether we spawn a good object or a bad object

        GameObject g = badObject;
        if (1000f * goodPercentage > r)
            g = goodObject;

        float distance = 1120; //sqrt(960^^2+540^2) + 20 ~ so it always spawns outside the screen in 16:9
        float angle = Random.Range(0f, 360f); //Random direction


        GameObject gO = GameObject.Instantiate(g, new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * distance, Quaternion.identity); 
        gO.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * -objectSpeed; //Multiplied by -1f so it moves to the center.
    }

    void AddTime()
    {
        //Function to decide how fast the objects spawn
        //The more points we have, the faster the objects spawn.
        float timeBetween;
        if (gameManager.score < 5)
            timeBetween = Random.Range(0.9f, 1.8f);
        else if (gameManager.score < 10)
            timeBetween = Random.Range(0.7f, 1.1f);
        else if (gameManager.score < 20)
            timeBetween = Random.Range(0.5f, 0.8f);
        else if (gameManager.score < 40)
            timeBetween = Random.Range(0.4f, 0.6f);
        else if (gameManager.score < 75)
            timeBetween = Random.Range(0.3f, 0.5f);
        else
            timeBetween = Random.Range(0.2f, 0.4f);

        if (Random.Range(0, 100) < 5)
            timeBetween += Random.Range(0.5f, 1f); //resting break


        timeLeftTillNextSpawn += timeBetween;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //We reduce the time left.
        //If its non-positive, that means, that there is no time left to spawn
        //Meaning we spawn an object, and add some time till the next spawn
        timeLeftTillNextSpawn -= Time.deltaTime;
        if (timeLeftTillNextSpawn <= 0f)
        {
            SpawnObject();
            AddTime();
        }
    }
}

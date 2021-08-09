using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Shield : MonoBehaviour
{
    float RealVector2Angle(Vector2 _in) //Like, why do you use weird logic, dear Vector2.Angle(...)?
    {
        float _out;
        _out = Mathf.Atan2(_in.y, _in.x);
        return _out;
    }

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        //We get where our mouse is currently at
        Vector2 position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Convert it to get the relative angle of the direction vector "position" to the center
        float angle = RealVector2Angle(position);

        //We rotate and change the position accordingly.
        //PS it might have been more elegant to only rotate the parent.
        transform.rotation = Quaternion.Euler(0,0,90f+angle*180/Mathf.PI); 
        transform.position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * 68f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Nothing if good object hits the boddy
        //Extra point if a bad object hits the body

        if (collision.tag == "GoodObject") ;
        else if (collision.tag == "BadObject")
            gameManager.AddScore(1);
        else return;
        Destroy(collision.gameObject);
    }
}

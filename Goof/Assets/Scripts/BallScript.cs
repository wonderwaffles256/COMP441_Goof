using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UIElements;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 shootDirection;
    Rigidbody2D _rbody;
    public float speed;
    private bool moving = false;
    Vector2 objectPosition;
    //private bool ballClicked = false;
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rbody.velocity.magnitude == 0 & moving)
        {
            moving = false;
            //ballClicked = false;
            Debug.Log("ball stopped");
        }
    }
    private void OnMouseDown()
    {
        if (!moving)
        { 
            objectPosition = transform.position;
            Debug.Log("Ball clicked");
            //ballClicked = true;
        }
        else
        {
            Debug.Log("Ball is still moving!");
        }
    }
    private void OnMouseUp()
    {
        if (!moving)
        {
            Debug.Log("Ball released");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - objectPosition;
            _rbody.AddForce(direction * -speed, ForceMode2D.Impulse);
            Debug.Log(direction.ToString() + " " + objectPosition.ToString() + " " + mousePosition.ToString());
            moving = true;
        }
        else
        {
            Debug.Log("Ball is still moving!");
        }
    }

}

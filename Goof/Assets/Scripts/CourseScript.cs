using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CourseScript : MonoBehaviour
{
    public int par;
    public float speed;
    Rigidbody2D _rbody;
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if the course is moving and if it has stopped
        if (_rbody.velocity.magnitude == 0 & ball.GetComponent<BallScript>()._moving)
        {
            ball.GetComponent<BallScript>()._moving = false;
            ball.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("ball stopped");
        }
    }

    public void destroyCourse()
    {
        Destroy(gameObject);
    }
    //method to hit the course
    public void hitCourse(Vector2 direction)
    {
        _rbody.AddForce(direction * -speed, ForceMode2D.Impulse);
    }
}

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
    public AudioClip hitCoursesound;
    AudioSource AudioSource;
    float maxspeed = 40f;
    //public Vector2 testspeed;
    Rigidbody2D _rbody;
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball");
        AudioSource = GetComponent<AudioSource>();
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
        if(_rbody.velocity.magnitude >= maxspeed)
        {
            Debug.Log(_rbody.velocity.magnitude);
            _rbody.velocity = Vector3.ClampMagnitude(_rbody.velocity, maxspeed);
        }
    }

    public void destroyCourse()
    {
        Destroy(gameObject);
    }
    //method to hit the course
    public void hitCourse(Vector2 direction)
    {
        AudioSource.PlayOneShot(hitCoursesound);
        if (speed * direction.magnitude > maxspeed)
        {
            _rbody.AddForce(direction.normalized * -maxspeed, ForceMode2D.Impulse);
        }
        else
        {
            _rbody.AddForce(direction * -speed, ForceMode2D.Impulse);
        }
        //_rbody.AddForce(testspeed, ForceMode2D.Impulse);
    }
}

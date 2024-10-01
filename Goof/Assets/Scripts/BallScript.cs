using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject course;
    public bool _moving = false;

    ManagerScript _manager;
    GameObject _arrow;
    SpriteRenderer _rend;
    SpriteRenderer _arrowSprite;
    Vector2 _shootDirection;
    Vector2 _objectPosition;
    Vector2 _mousePosition;
    Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindAnyObjectByType<ManagerScript>();
        _rend = GetComponent<SpriteRenderer>();
        //set up the arrow that shows the direction you are hitting
        _arrow = GameObject.FindGameObjectWithTag("Arrow");
        _arrowSprite = _arrow.GetComponent<SpriteRenderer>();
        _arrowSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseDown()
    {
        //The course isn't moving
        if (!_moving)
        {
            //record the balls position and make the arrow appear when ball is clicked
            _objectPosition = transform.position;
            _arrowSprite.enabled = true;
            _arrowSprite.transform.position = _objectPosition;
            Debug.Log("Ball clicked");
        }
        else
        {
            Debug.Log("Ball is still moving!");
        }
    }
    private void OnMouseDrag()
    {
        if (!_moving)
        {
            //find the mouse position and the direction from the ball to the mouse
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _direction = _mousePosition - _objectPosition;
            //find the angle from the ball to the mouse and make the arrow show that direction
            float angle = Mathf.Atan2(-_direction.y, -_direction.x) * Mathf.Rad2Deg;
            _arrowSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnMouseUp()
    {
        if (!_moving)
        {
            Debug.Log("Ball released");
            _manager.addStroke();
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //call on the method in managerscript to hit the course
            course.GetComponent<CourseScript>().hitCourse(_direction);
            _arrowSprite.enabled = false;//turn off the arrow
            _moving = true;//course is now moving
            _rend.color = Color.grey;//change the balls color
        }
        else
        {
            Debug.Log("Ball is still moving!");
        }
    }
}

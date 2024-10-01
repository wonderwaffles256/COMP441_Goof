using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject course;
    GameObject arrow;
    SpriteRenderer _rend;
    SpriteRenderer arrowSprite;
    public bool _moving = false;
    Vector2 shootDirection;
    Vector2 _objectPosition;
    Vector2 mousePosition;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        //set up the arrow that shows the direction you are hitting
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        arrowSprite = arrow.GetComponent<SpriteRenderer>();
        arrowSprite.enabled = false;
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
            arrowSprite.enabled = true;
            arrowSprite.transform.position = _objectPosition;
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
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - _objectPosition;
            //find the angle from the ball to the mouse and make the arrow show that direction
            float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            arrowSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnMouseUp()
    {
        if (!_moving)
        {
            Debug.Log("Ball released");
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //call on the method in managerscript to hit the course
            course.GetComponent<CourseScript>().hitCourse(direction);
            arrowSprite.enabled = false;//turn off the arrow
            _moving = true;//course is now moving
            _rend.color = Color.grey;//change the balls color
        }
        else
        {
            Debug.Log("Ball is still moving!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBallScript : MonoBehaviour
{
    Vector2 shootDirection;
    SpriteRenderer _rend;
    GameObject arrow;
    GameObject course;
    SpriteRenderer arrowSprite;
    public bool _moving = false;
    Vector2 _objectPosition;
    Vector2 mousePosition;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        course = GameObject.FindGameObjectWithTag("Course");
        arrowSprite = arrow.GetComponent<SpriteRenderer>();
        arrowSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (!_moving)
        {
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
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePosition - _objectPosition;
            float distance = Vector2.Distance(_objectPosition, mousePosition);
            float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            arrowSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    private void OnMouseUp()
    {
        if (!_moving)
        {
            Debug.Log("Ball released");
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //_rbody.AddForce(direction * -speed, ForceMode2D.Impulse);
            course.GetComponent<CourseScript>().hitCourse(direction);
            arrowSprite.enabled = false;
            _moving = true;
            _rend.color = Color.grey;
        }
        else
        {
            Debug.Log("Ball is still moving!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TestBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 shootDirection;
    Rigidbody2D _rbody;
    SpriteRenderer _rend;
    GameObject arrow;
    SpriteRenderer arrowSprite;
    public float speed;
    bool _moving = false;
    Vector2 _objectPosition;
    Vector2 mousePosition;
    Vector2 direction;
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        arrowSprite = arrow.GetComponent<SpriteRenderer>();
        arrowSprite.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_rbody.velocity.magnitude == 0 & _moving)
        {
            _moving = false;
            _rend.color = Color.white;
            Debug.Log("ball stopped");
        }
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
            _rbody.AddForce(direction * -speed, ForceMode2D.Impulse);
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

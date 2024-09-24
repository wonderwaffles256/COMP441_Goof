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
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 objectPosition = transform.position;
            Vector2 direction = mousePosition - objectPosition;
            _rbody.AddForce(direction * speed, ForceMode2D.Impulse);
            Debug.Log(direction.ToString());
        }
    }
}

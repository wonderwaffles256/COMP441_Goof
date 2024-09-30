using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Transform))]
public class CameraScript : MonoBehaviour
{
    Transform _trans;
    Vector2 _scrollVector;
    // Start is called before the first frame update
    void Start()
    {
        _trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnScroll(InputValue value)
    {
        _scrollVector = value.Get<Vector2>();
        Debug.Log($"{_scrollVector}");
    }
}

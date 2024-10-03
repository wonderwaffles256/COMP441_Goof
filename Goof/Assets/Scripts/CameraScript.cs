using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    public float maxZoom;
    Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnZoom(InputValue value)
    {
        float direction = value.Get<float>();
        if (direction > 0)
        {
            Debug.Log($"Zoomed in");
            if (_cam.orthographicSize > 1)
            {
                _cam.orthographicSize--;
            }
        }
        if (direction < 0)
        {
            Debug.Log($"Zoomed out");
            if (_cam.orthographicSize < maxZoom)
            {
                _cam.orthographicSize++;
            }
        }

    }
}

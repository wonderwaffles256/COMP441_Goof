using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolesScript : MonoBehaviour
{
    MainSceneManager _manager;
    // Start is called before the first frame update
    void Start()
    {
        _manager = FindAnyObjectByType<MainSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            Debug.Log("Sunk Ball");
            _manager.OnHoleDetection();
        }
        Debug.Log("Detected Trigger");

    }
}

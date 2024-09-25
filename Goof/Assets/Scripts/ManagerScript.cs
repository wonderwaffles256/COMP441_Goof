using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MainSceneManager : MonoBehaviour
{
    public TMP_Text courseNumber;
    public TMP_Text strokeCount;
    public TMP_Text winMessage;
    public string[] winMessages;
    public int par;

    int _strokes;
    bool _inHole;

    // Start is called before the first frame update
    void Start()
    {
        _strokes = 0;
        _inHole = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inHole)
        {

        }
    }

    public void addStroke()
    {
        _strokes++;
        strokeCount.text = _strokes.ToString();
    }

}

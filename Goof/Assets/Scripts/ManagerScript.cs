using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MainSceneManager : MonoBehaviour
{
    public TMP_Text courseNumberText;
    public TMP_Text strokeCountText;
    public TMP_Text winMessageText;
    public string[] winMessages;
    public int courseNumber;

    int _strokeCount;
    bool _hasWon;

    // Start is called before the first frame update
    void Start()
    {
        _strokeCount = 0;
        _hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasWon)
        {

        }
    }

    public void addStroke()
    {
        _strokeCount++;
        strokeCountText.text = _strokeCount.ToString();
    }

    public void OnHoleDetection()
    {
        _hasWon = true;
        winMessageText.text = winMessages[(_strokeCount > 0 && _strokeCount <= winMessages.Length) ? _strokeCount - 1 : 0];
    }

}

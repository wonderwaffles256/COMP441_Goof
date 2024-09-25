using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ManagerScript : MonoBehaviour
{
    public TMP_Text courseNumberText;
    public TMP_Text strokeCountText;
    public TMP_Text winMessageText;
    public TMP_Text parText;
    public GameObject[] coursePrefabs;
    public string[] winMessages;
    public int courseNumber;

    GameObject _currCourse;
    CourseScript _currCourseScript;
    int _strokeCount;
    bool _hasWon;
    string _winMessage;

    // Start is called before the first frame update
    void Start()
    {
        _currCourse = coursePrefabs[(courseNumber >=0) ? courseNumber : 0];
        Instantiate(_currCourse, new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        _currCourseScript = _currCourse.GetComponent<CourseScript>();
        _strokeCount = 0;
        _hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasWon && Input.GetKey(KeyCode.Space))
        {
            // Arrest controls
            nextCourse();
        }
        courseNumberText.text = courseNumber.ToString();
        parText.text = _currCourseScript.par.ToString();
    }

    public void addStroke()
    {
        _strokeCount++;
        strokeCountText.text = _strokeCount.ToString();
    }

    void nextCourse()
    {
        
        _currCourseScript.destroySelf();
        courseNumber = (courseNumber < 0 || courseNumber > coursePrefabs.Length) ? 1 : courseNumber++;
        _currCourse = coursePrefabs[courseNumber - 1];
        Instantiate(_currCourse, new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
    }

    public void OnHoleDetection()
    {
        _hasWon = true;
        int par = _currCourseScript.par;
        // # strokes above or below par. Assumes below par
        int belowPar = _strokeCount - par;
        // Calculates index of win message array
        int index = par + belowPar - 1;
        if (index >= 0 && index < winMessages.Length)
        {
            _winMessage = winMessages[index];
        }
        else if (index >= winMessages.Length)
        {
            _winMessage = "+" + par.ToString() + " over Par";
        }
        winMessageText.text = _winMessage;
    }

}

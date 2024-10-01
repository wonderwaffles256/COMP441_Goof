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
    public TMP_Text continueText;
    public GameObject[] coursePrefabs;
    public string[] winMessages;
    public int courseNumber;

    GameObject _currCourse;
    CourseScript _currCourseScript;
    BallScript _ballScript;
    int _strokeCount;
    bool _hitHole;
    string _winMessage;

    private void Awake()
    {
        courseNumber = (courseNumber > 0 && courseNumber <= coursePrefabs.Length) ? courseNumber : 1;
        // Instantiate 1st course based on course number
        _currCourse = Instantiate(coursePrefabs[courseNumber - 1], new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        // Get script of 1st loaded course
        _currCourseScript = _currCourse.GetComponent<CourseScript>();
        // Get the ball's script
        _ballScript = FindAnyObjectByType<BallScript>();
        // Pass 1st course to BallScript for control
        _ballScript.course = _currCourse;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set course number text to course number
        courseNumberText.text = courseNumber.ToString();
        // Set par to course's par value
        parText.text = "Par: " + _currCourseScript.par.ToString();
        // Disable irrelevant UI
        winMessageText.enabled = false;
        continueText.enabled = false;
        // Setup relevant values
        _strokeCount = 0;
        _hitHole = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_hitHole)
        {
            // TODO: Arrest controls
            winMessageText.enabled = true;
            continueText.enabled = true;
        }
        if (_hitHole && Input.GetKey(KeyCode.Space))
        {
            nextCourse();
            _strokeCount = 0;
            winMessageText.enabled = false;
            continueText.enabled = false;
            _hitHole = false;
        }
        strokeCountText.text = "Stroke: " + _strokeCount.ToString();
    }

    public void addStroke()
    {
        _strokeCount++;  
    }

    void nextCourse()
    {
        // Increment the course number
        courseNumber = (courseNumber > 0 && courseNumber <= coursePrefabs.Length) ? courseNumber + 1 : 1;
        // Grab next prefab before it's script is destroyed
        GameObject tempPrefab = coursePrefabs[courseNumber - 1];
        // Remove current course from scene
        _currCourseScript.destroyCourse();
        // Set current course to next course
        Debug.Log(coursePrefabs.Length.ToString());
        _currCourse = Instantiate(tempPrefab, new Vector2(0, 0), new Quaternion(0, 0, 0, 0));
        // Get next course's script
        _currCourseScript = _currCourse.GetComponent<CourseScript>();
        // Pass new course to BallScript
        _ballScript.course = _currCourse;
        // Set course-specific UI text
        courseNumberText.text = courseNumber.ToString();
        parText.text = "Par: " + _currCourseScript.par.ToString();
    }

    public void OnHoleDetection()
    {
        _hitHole = true;
        int par = _currCourseScript.par;
        // # strokes above or below par. Assumes below par
        int abovePar = _strokeCount - par;
        // Find # of elements par is away from PAR text in the array (PAR is 5th element)
        int relIndex = 5 - par;
        // Calculates index of win message array
        int index = relIndex + par + abovePar - 1;
        // Decides win message based on index
        if (_strokeCount == 1)
        {
            _winMessage = winMessages[0];
        }
        else if (index >= 0 && index < winMessages.Length)
        {
            _winMessage = winMessages[index];
        }
        else if (index >= winMessages.Length)
        {
            _winMessage = abovePar.ToString() + " over Par";
        }
        else
        {
            _winMessage = "ERROR";
        }
        winMessageText.text = _winMessage;
    }

}

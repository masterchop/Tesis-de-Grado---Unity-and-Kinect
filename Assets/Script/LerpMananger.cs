using UnityEngine;
using System.Collections;

public class LerpMananger : MonoBehaviour
{
    private LerpObject lerpObject;
    private GestureListener gestureListener;

    public GameObject Pause;
    public int objects;
    public GameObject Control;
    private int count;
    private bool pause = false;
    private int angle;

    public bool completed;

    // Use this for initialization
    void Start()
    {
        completed = false;
        angle = PlayerPrefs.GetInt("Angle");
        if (Pause != null)
            Pause.SetActive(pause);
        count = 1;
        lerpObject = FindObjectOfType<LerpObject>();
        gestureListener = FindObjectOfType<GestureListener>();
        if (Application.loadedLevelName == "Menu")
        {
            lerpObject.enabled = true;
        }
        completed = true;
    }
    // Update is called once per frame
    void Update()
    {
        KinectWrapper.NuiCameraElevationSetAngle(angle);
        if (Application.loadedLevelName == "Menu")
        {
            MenuScene();
        }
        if (Application.loadedLevelName == "Game v1")
        {
            Game01();
        }
        if (Application.loadedLevelName == "Intro")
        {
            Intro();
        }
        if (Application.loadedLevelName == "Score")
        {
            Score();
        }
    }

    void Score()
    {
        if (Input.GetKeyDown(KeyCode.R) || gestureListener.IsRaiseRightHand() || gestureListener.IsSwipeLeft())
        {
            Application.LoadLevel("Menu");
        }
    }


    void Game01()
    {
        if (Input.GetKeyDown(KeyCode.Space) || gestureListener.IsSwipeRight())
        {
            print(FindObjectOfType<Control>());
            Destroy(FindObjectOfType<Control>().Intro);
        }
    }

    void Intro()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || gestureListener.IsClick() || gestureListener.IsSwipeLeft())
        {
            Application.LoadLevel("Game v1");
        }
    }

    void MenuScene()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || gestureListener.IsSwipeRight())
        {
            if (count != objects)
            {
                count++;
                lerpObject.Right = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || gestureListener.IsSwipeLeft())
        {
            Control.SetActive(false);
            if (count != 1)
            {
                count--;
                lerpObject.Left = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || gestureListener.IsClick())
        {
            switch (count)
            {
                case 1:
                    PlayerPrefs.SetInt("Angle", angle);
                    Application.LoadLevel("Game v1");
                    break;
                case 2:
                    lerpObject.Other = GameObject.Find("configuration").transform;
                    lerpObject.moving = true;
                    Control.SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }

    public void SetUpAngle()
    {
        if (angle < 30)
        {
            angle += 5;
        }
    }
    public void SetDownAngle()
    {
        if (angle > -30)
        {
            angle -= 5;
        }
    }
}

using UnityEngine;
using System.Collections;

public class Result : MonoBehaviour
{
    public UnityEngine.UI.Text Max;
    public UnityEngine.UI.Text Score;
    private GestureListener gestureListener;

    // Use this for initialization
    void Start()
    {
        gestureListener = FindObjectOfType<GestureListener>();
        int temp = PlayerPrefs.GetInt("Score");
        int score = PlayerPrefs.GetInt("Temp");
        if (temp < score)
        {
            Max.text = score.ToString();
            PlayerPrefs.SetInt("Score", score);
        }
        else
        {
            Max.text = temp.ToString();
        }
        Score.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gestureListener.IsRaiseRightHand() || Input.GetKeyDown(KeyCode.P))
        {
            Application.LoadLevel("Menu");
        }
    }
}

using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{

    public UnityEngine.UI.Text time;
    public UnityEngine.UI.Text score;
    public UnityEngine.UI.Image Intro;

    public int Timer;
    private int _time, _score;
    private int data;

    // Use this for initialization
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Intro == null)
        {
            _time = Timer - Mathf.RoundToInt(Time.time * 1f) + data;
            time.text = _time.ToString();
            score.text = _score.ToString();
            if (_time < 0)
            {
                PlayerPrefs.SetInt("Temp", _score);
                Application.LoadLevel("Score");
            }
        }
        else
            data = Mathf.RoundToInt(Time.time * 1f);
    }

    public void AddTime()
    {
        Timer += 5;
    }

    public void AddScore(int value)
    {
        _score += value;
    }
}

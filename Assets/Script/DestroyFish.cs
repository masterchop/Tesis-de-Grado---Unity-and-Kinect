using UnityEngine;
using System.Collections;

public enum fish
{
    good,
    bad,
    time
}

public class DestroyFish : MonoBehaviour
{
    public fish type;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.gameObject.name == "Create" || other.gameObject.name == "Generate")
        {
            Destroy(transform.gameObject);
        }
        if (other.gameObject.name == "joint_HandLT" || other.gameObject.name == "joint_HandRT")
        {
            //ControlPoints points = FindObjectOfType<ControlPoints>();
            Control control = FindObjectOfType<Control>();
            switch (type)
            {
                case fish.good:
                    control.AddScore(1);
                    //points.AddCount(1);
                    break;
                case fish.bad:
                    control.AddScore(-1);
                    //points.AddCount(-1);
                    break;
                case fish.time:
                    control.AddTime();
                    //ControlTime _time = FindObjectOfType<ControlTime>();
                    //if (_time.image.fillAmount - 10 > 0)
                    //    _time.image.fillAmount -= 10;
                    break;
                default:
                    break;
            }
            Destroy(transform.gameObject);
        }
    }
}

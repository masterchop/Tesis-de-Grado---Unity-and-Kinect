using UnityEngine;
using System.Collections;

public class LerpObject : MonoBehaviour
{
    public Transform position1;
    public Transform position2;

    public Transform Other;
    public Transform temp;

    // Auxiliar variables
    protected Transform destination;

    // How fast the character moves
    public float speed = 1.0f;

    // Two types of lerp
    public enum LerpType { Constant, Smooth };
    public LerpType lerpType;

    // Constant Lerp variables
    protected float timer = 0.0f;

    public bool Right, Left;
    public bool Up, Down;
    public bool moving;

    // Initialization
    void Start()
    {
        destination = position1;
        Right = Left = false;
    }
    // Lerp is done over time
    void Update()
    {
        // Check for the selected type of lerp
        switch (lerpType)
        {
            case LerpType.Constant:
                // From position1 to position2 with incresing t
                transform.position = Vector3.Lerp(position1.position, position2.position, speed * timer);
                break;
            case LerpType.Smooth:
                // From actual position to destination with "constant" t
                transform.position = Vector3.Lerp(transform.position, destination.position, speed * 3.0f * Time.deltaTime);
                break;
        }
        // Increase or decrease the constant lerp timer
        if (destination == position1)
        {
            // Go to position1 t = 0.0f
            timer = Mathf.Clamp(timer - Time.deltaTime, 0.0f, 1.0f / speed);
        }
        else
        {
            // Go to position2 t = 1.0f
            timer = Mathf.Clamp(timer + Time.deltaTime, 0.0f, 1.0f / speed);
        }

        if (Right || Left)
        {
            Vector3 v = position2.transform.position;
            v.x += Right ? 25 : -25;
            temp = position2;
            position2 = Instantiate(position2.transform, v, position1.rotation) as Transform;
            destination = position2;
            Destroy(temp.gameObject);
            Right = Left = false;
        }
        if (Up || Down)
        {
            Vector3 v = position2.transform.position;
            v.y += Up ? 25 : -25;
            temp = position2;
            position2 = Instantiate(position2.transform, v, position1.rotation) as Transform;
            destination = position2;
            Destroy(temp.gameObject);
            Up = Down = false;
        }
        if (moving)
        {
            destination = Other;
            moving = false;
        }
    }
}

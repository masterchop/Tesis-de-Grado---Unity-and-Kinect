using UnityEngine;
using System.Collections;

public class GenerateFish : MonoBehaviour
{
    public GameObject[] _objects;
    public bool isFiring;
    public float triggerTime;
    private float currentTime;
    public float thrust;
    public Vector3 vectorForce = new Vector3();

    // Use this for initialization
    void Start()
    {
        triggerTime = Random.Range(2, triggerTime + 3);
        currentTime = 0;
        isFiring = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= triggerTime)
            {
                int i = Random.Range(0, _objects.Length);
                Vector3 v = transform.position;
                v.y += 1f;
                v.x = Random.Range(-2f, 1.4f);
                GameObject fish = Instantiate(_objects[i], v, _objects[i].transform.rotation) as GameObject;
                //GameObject fish = Instantiate(_objects[i], v, _objects[i].transform.rotation) as GameObject;
                fish.GetComponent<Rigidbody>().AddForce(vectorForce * thrust, ForceMode.Impulse);
                currentTime = 0;
            }
        }
    }
}

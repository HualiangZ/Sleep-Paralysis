using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLerp : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform self;
    public GameObject girl;
    public float x;
    public float y;
    public float z;
    void Start()
    {
        open();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void close()
    {
        transform.position = new Vector3(5.98f,2.19f, 4.02f);
        transform.Rotate(0, 0, 0);
        gameObject.tag = "Untagged";
        girl.SetActive(false);
    }
    void open () 
    {
        transform.Rotate(x, y, z);
        gameObject.tag = "Abnormal";
        girl.SetActive(true);
    }
}

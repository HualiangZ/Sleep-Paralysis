using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addforce : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    //private GameObject self;
    private Vector3 defultLocation;
    public bool detected = false;
    public bool change = false;
    public int force;
    public int rotateY;
    void Start()
    {
        defultLocation = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
        //self = GetComponent<GameObject>();

        StartCoroutine(AddForce());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AddForce()
    {
        for(; ; )
        {
            int sec = Random.Range(5, 10);
            int rand = Random.Range(0, 100);
            if(gameObject.tag != "Abnormal" && rand <=10)
            {
                rb.AddForce(-transform.forward * force);
                gameObject.tag = "Abnormal";
                change = true;
            }
            yield return new WaitForSeconds(sec);
            
        }
       
    }

    public void Normal()
    {
        if(detected)
        {
            transform.position = defultLocation;
            gameObject.transform.eulerAngles = new Vector3(0,rotateY, 0);
            gameObject.tag = "Untagged";
            detected = false;
            change = false;
        }
    }
}

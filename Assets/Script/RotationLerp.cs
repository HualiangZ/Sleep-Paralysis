using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLerp : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 defultLocation;
    public GameObject girl;
    public float x;
    public float y;
    public float z;
    void Start()
    {
        defultLocation = gameObject.transform.position;
        StartCoroutine(Open());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Close()
    {
        //transform.position = defultLocation;
        transform.Rotate(-x, -y, -z);
        gameObject.tag = "Untagged";
        girl.SetActive(false);
    }
    IEnumerator Open() 
    {
        for(; ; )
        {
            int sec = Random.Range(10, 15);
            int rand = Random.Range(0, 100);
            if(gameObject.tag != "Abnormal" && rand <= 5)
            {
                transform.Rotate(x, y, z);
                gameObject.tag = "Abnormal";
                girl.SetActive(true);
            }
            yield return new WaitForSeconds(sec);
        }
        
    }

    
}

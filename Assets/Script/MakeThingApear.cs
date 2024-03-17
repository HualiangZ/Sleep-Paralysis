using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeThingApear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hanger;
    public GameObject ghost;
    public bool detected = false;
    void Start()
    {
        StartCoroutine(Appear());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("b");
    }

    public IEnumerator Appear()
    {
        for (; ; )
        {
            
            int sec = Random.Range(2, 2);
            yield return new WaitForSeconds(sec);
            int rand = Random.Range(0, 100);
            if (gameObject.tag != "Abnormal" && rand <= 120)
            {          
                ghost.gameObject.SetActive(true);
                gameObject.tag = "Abnormal"; 
            }
            

        }

    }

    public void Normal()
    {
        Debug.Log("a");
        if (detected)
        {
            Debug.Log("b");
            gameObject.tag = "Untagged";
            detected = false;
            ghost.gameObject.SetActive(false);
            
        }
    }


}

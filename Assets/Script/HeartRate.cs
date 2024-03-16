using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartRate : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text heart;
    private int abnormalCount = 0;
    GameObject[] allObjects;
    private void Awake()
    {
        allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
    }
    void Start()
    {
        StartCoroutine(Check());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Check() 
    {
        for(; ; )
        {
            abnormalCount = 0;
            foreach (GameObject obj in allObjects)
            {
                if (obj.tag == "Abnormal")
                {
                    abnormalCount += 1;                
                }      
            }
            heart.text = abnormalCount.ToString();
            yield return new WaitForSeconds(2f);
        }

    }

}

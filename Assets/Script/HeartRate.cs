using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartRate : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text heart;
    private int abnormalCount = 0;
    private int defultHeartRate = 60;
    private int maxHeartRate = 60;
    private int currentHeartRate = 60;
    private int temp = 0;
    public GameObject gameOver;
    GameObject[] allObjects;
    private void Awake()
    {
        allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
    }
    void Start()
    {
        StartCoroutine(Check());
        StartCoroutine(HR());
        StartCoroutine(UpdateCurrentHR());

    }

    // Update is called once per frame
    void Update()
    {
        if(temp > 200)
        {
            gameOver.SetActive(true);
        }
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

    IEnumerator HR()
    {
        for(; ; )
        {
            //currentHeartRate = 60 + Random.Range(-2,2);
            maxHeartRate = defultHeartRate * (abnormalCount+1);
            //heart.text = count.ToString();
            if (currentHeartRate < maxHeartRate)
            {
                currentHeartRate += 3;
            }
            else if(currentHeartRate > maxHeartRate)
            {
                currentHeartRate -= 3;
            }
            else
            {
                currentHeartRate = maxHeartRate;
            }
            yield return new WaitForSeconds(2f); 
        }
    }

    IEnumerator UpdateCurrentHR()
    {
        for(; ; )
        {
            temp = currentHeartRate + Random.Range(-2, 2);
            heart.text = (currentHeartRate + Random.Range(-2, 2)).ToString();
            yield return new WaitForSeconds(1f);
        }
    }

}

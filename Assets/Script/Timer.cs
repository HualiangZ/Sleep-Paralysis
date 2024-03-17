using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeLeft;
    public TMP_Text timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            updateTimer(timeLeft);
        }else
        {           
            SceneManager.LoadScene(3);
        }
            
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);

        timer.text = string.Format("{0:00} : {1:00}", min, sec);
    }
}

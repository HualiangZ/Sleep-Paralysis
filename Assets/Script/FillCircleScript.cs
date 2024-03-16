using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class FillCircleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 2f;
    public float maxTimer = 2f;

    public Image circle;

    private bool shouldUpdate;
    private void Start()
    {
        circle.enabled = false;
    }
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            timer -= Time.deltaTime;
            circle.enabled = true;
            circle.fillAmount = timer / 2;
            if (timer <= 0)
            {
                timer = maxTimer;
                circle.fillAmount = 1;
                circle.enabled = false;
            }
        }
        else
        {
            if (shouldUpdate)
            {
                timer = maxTimer;
                circle.fillAmount = 1;
                circle.enabled = false;
                shouldUpdate = false;
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            shouldUpdate = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject blink;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(BlinkEff(blink));
        }
    }

    public IEnumerator BlinkEff(GameObject blink)
    {
        blink.SetActive(true);
        yield return new WaitForSeconds(.2f);
        blink.SetActive(false);
        yield return null;
    }
}

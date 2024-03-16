using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using UnityEngine;

public class ChangeMatScript : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    public Material defaultMat;
    public bool changed = false;
    public bool detected = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChanceOfChange());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ChanceOfChange()
    {
        for(; ; )
        {
            int sec = UnityEngine.Random.Range(5, 10);
            if (gameObject.tag != "Abnormal")
            {
                int i = UnityEngine.Random.Range(0, 100);
                if (i <= 5)
                {
                    ChangeMat();
                    gameObject.tag = "Abnormal";
                    changed = true;
                }
            }
            yield return new WaitForSeconds(sec);
        }
 
    }

    public void Normal()
    {
        if (detected)
        {
            gameObject.GetComponent<Renderer>().material = defaultMat;
            gameObject.tag = "Untagged";
            detected = false;
            changed = false;
        }
    }

    void ChangeMat()
    {
        int element = UnityEngine.Random.Range(0, materials.Count);
        gameObject.GetComponent<Renderer>().material = materials[element];
    }
}

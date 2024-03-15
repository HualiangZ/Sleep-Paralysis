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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChanceOfChange()
    {
            if (!changed)
            {
                int i = UnityEngine.Random.Range(0, 10);
                if (i <= 5)
                {
                    ChangeMat();
                    gameObject.tag = "Abnormal";
                    changed = true;
                }
            }
    }

    public void Normal()
    {
        if (detected)
        {
            gameObject.GetComponent<Renderer>().material = defaultMat;
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMatScript : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    public Material defaultMat;
    public bool changed = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChanceOfChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChanceOfChange()
    {
        for (; ; )
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
            yield return new WaitForSeconds(2f);
        }

    }

    void ChangeMat()
    {
        int element = UnityEngine.Random.Range(0, materials.Count);
        gameObject.GetComponent<Renderer>().material = materials[element];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveForward : MonoBehaviour
{
    public GameObject target;
    public GameObject ghost;
    private Collider selfCollider;
    public bool detected = false;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Appear());
        selfCollider = GetComponent<Collider>();
        selfCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (detected)
        {
            Normal();
            Finish();
        }
    }

    public void Normal()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 20 * Time.deltaTime);
        
    }

    private void Finish()
    {
        if (target.transform.position == transform.position)
        {
            gameObject.tag = "Untagged";
            transform.position = new Vector3(-0.21f, 1.248f, 5.7f);
            detected = false;
            ghost.gameObject.SetActive(false);
            selfCollider.enabled = false;   
        }

    }

    IEnumerator Appear()
    {
        for (; ; )
        {
            int sec = Random.Range(10, 20);
            int rand = Random.Range(0, 100);
            if(gameObject.tag != "Abnormal" && rand <= 3)
            {
                ghost.gameObject.SetActive(true);
                gameObject.tag = "Abnormal";
                selfCollider.enabled = true;
            }
            yield return new WaitForSeconds(sec);
            
        }
        
    }
}

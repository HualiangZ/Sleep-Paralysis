using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveForward : MonoBehaviour
{
    public GameObject target;
    public GameObject ghost;
    private Collider selfCollider;
    private Vector3 defaultLocation;
    public bool detected = false;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Appear());
        defaultLocation = transform.position;
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
            //transform.position = new Vector3(-0.21f, 1.248f, 5.7f);
            transform.position = defaultLocation;
            detected = false;
            ghost.gameObject.SetActive(false);
            selfCollider.enabled = false;   
        }

    }

    IEnumerator Appear()
    {
        for (; ; )
        {
            int sec = Random.Range(5, 10);
            yield return new WaitForSeconds(sec);
            int rand = Random.Range(0, 100);
            if(gameObject.tag != "Abnormal" && rand <= 4)
            {
                ghost.gameObject.SetActive(true);
                gameObject.tag = "Abnormal";
                selfCollider.enabled = true;
            }
            
            
        }
        
    }
}

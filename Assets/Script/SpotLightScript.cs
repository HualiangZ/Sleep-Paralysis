using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpotLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 turn;
    RaycastHit hit;
    public GameObject blink;
    private BlinkScript blinkObject;
    private float holdDownTime = 2;
    void Start()
    {
        blinkObject = GetComponent<BlinkScript>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLight();

        if (Input.GetMouseButton(0))
        {
            holdDownTime -= Time.deltaTime;
            Debug.Log(holdDownTime);
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            holdDownTime = 2;
        }
        if (holdDownTime <= 0)
        {
            StartCoroutine(BlinkEff(blink));
            DetectTags();
            holdDownTime = 2;
        }

    }

    private void MoveLight()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    private void DetectTags()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject.tag == "Abnormal") 
            {
                Debug.Log("true");
            }
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

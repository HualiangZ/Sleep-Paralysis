using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpotLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 turn;
    RaycastHit hit;
    public GameObject blink;
    public GameObject hiObj;
    private ChangeMatScript changeMatScript;
    private Addforce forceScript;
    private RotationLerp door;
    private MoveForward ghost;
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
            //Debug.Log(holdDownTime);
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            holdDownTime = 2;
        }
        if (holdDownTime <= 0)
        {
            StartCoroutine(BlinkEff(blink));
            DetectChange();
            holdDownTime = 2;
        }

    }

    private void MoveLight()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    private void DetectChange()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            //hiObj = hit.collider.gameObject;
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Abnormal") 
            {
                Debug.Log("true");
                try
                {
                    changeMatScript = hit.collider.gameObject.GetComponent<ChangeMatScript>();
                    changeMatScript.detected = true;
                    changeMatScript.Normal();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }

                try
                {
                    door = hit.collider.gameObject.GetComponent<RotationLerp>();
                    //door.detected = true;
                    door.Close();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }

                try
                {
                    forceScript = hit.collider.gameObject.GetComponent<Addforce>();
                    forceScript.detected = true;
                    forceScript.Normal();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
                try
                {
                    ghost = hit.collider.gameObject.GetComponent<MoveForward>();
                    ghost.detected = true;
                    ghost.Normal();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }


                /*                hit.collider.gameObject.GetComponent<Renderer>().material = changeMatScript.defaultMat;
                                changeMatScript.changed = false;*/
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

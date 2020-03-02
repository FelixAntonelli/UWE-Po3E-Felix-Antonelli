using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;

    private void Awake()
    {
        liveCam = Camera.allCameras[0];
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        if (other == PlayerCollider)
        {
            Vector3 moveCam = new Vector3(liveCam.transform.localPosition.x, liveCam.transform.localPosition.y, liveCam.transform.localPosition.z - 10);
           /// moveCam = liveCam.transform.TransformDirection(moveCam);
            liveCam.transform.localPosition = moveCam;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}

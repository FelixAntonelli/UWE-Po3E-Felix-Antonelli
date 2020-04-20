using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelCam : MonoBehaviour
{
    public Camera tunnelCam;
    public Camera mainCam;
    public RayCastHideObject rayCastScript;
    private GameObject PlayerCharacter;
    private Collider PlayerCollider;

    private bool inside;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider)
        {
            inside = true;
            rayCastScript.stopScript();
            LerpBetweenCameras.Instance.LerpCameras(mainCam, tunnelCam);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            inside = false;
            LerpBetweenCameras.Instance.LerpCameras(tunnelCam, mainCam);
            rayCastScript.startScript();
        }
    }
}

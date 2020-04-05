using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    public Camera playerCam;
    public Camera staticCam;
    public Transform player;
    public Transform pod;
    public RayCastHideObject RayCastHideObject;

    private bool lerpDone = false;

    private void OnTriggerStay(Collider other)
    {
        if (!lerpDone)
        {
            LerpBetweenCameras.Instance.LerpCameras(playerCam, staticCam);
            lerpDone = true;
        }
        player.parent = pod;
        RayCastHideObject.stopScript();
        pod.position = new Vector3(pod.position.x, pod.position.y + 5 * Time.deltaTime, pod.position.z);
    }
}

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
    public DamageShips damage;

    private bool lerpDone = false;
    private bool go = false;

    private void OnTriggerExit(Collider other)
    {
        if (damage.getShipsDead())
        {
            if (!lerpDone)
            {
                LerpBetweenCameras.Instance.LerpCameras(playerCam, staticCam);
                lerpDone = true;
            }
            player.parent = pod;
            RayCastHideObject.stopScript();
            go = true;
        }
    }
    private void Update()
    {
        if (go)
        {
            pod.position = new Vector3(pod.position.x, pod.position.y + 8 * Time.deltaTime, pod.position.z);
            staticCam.transform.LookAt(player);
        }
    }
}

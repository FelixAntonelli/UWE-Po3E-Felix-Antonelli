using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpBetweenCameras : MonoBehaviour
{
    public static LerpBetweenCameras Instance;
    public Camera mainCam;
    private Camera startCam;
    private Camera endCam;
    private bool lerp = false;
    private float lerpTimer = 0;
    private float smooth = 2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        mainCam.enabled = false;
    }

    public void LerpCameras(Camera I_startCam, Camera I_endCamera)
    {
        startCam = I_startCam;
        endCam = I_endCamera;
        mainCam.transform.position = startCam.transform.position;
        mainCam.transform.rotation = startCam.transform.rotation;
        startCam.enabled = false;
        endCam.enabled = false;
        mainCam.enabled = true;
        lerpTimer = 0;
        lerp = true;
    }

    private void Update()
    {
        if (lerp)
        {
            lerpTimer += Time.deltaTime * smooth;
            mainCam.transform.position = Vector3.Lerp(startCam.transform.TransformPoint(startCam.transform.localPosition), endCam.transform.TransformPoint(endCam.transform.localPosition), lerpTimer);
            mainCam.transform.rotation = Quaternion.Lerp(startCam.transform.rotation, endCam.transform.rotation, lerpTimer);

            if (lerpTimer >= 1)
            {
                endCam.enabled = true;
                startCam.enabled = false;
                mainCam.enabled = false;
                lerp = false;
                lerpTimer = 0;
            }
        }
    }
}

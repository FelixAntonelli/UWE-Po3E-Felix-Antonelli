using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public Transform start;

    bool battery = false;
    public Transform BatteryPos;
    public Transform BatteryLook;

    bool Slot = false;
    public Transform SlotPos;
    public Transform SlotLook;

    bool Gun = false;
    public Transform GunPos;
    public Transform GunLook;

    bool Escape = false;
    public Transform EscapePos;
    public Transform EscapeLook;

    public Camera cutSceneCam;
    public Camera mainCam;
    public RayCastHideObject rayCastScript;


    private float lerpTimer = 0;
    private float smooth = 0.5f;
    private Transform pos1;
    private Transform pos2;

    private void Awake()
    {
        cutSceneCam.transform.position = start.position;
        battery = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (battery)
        {
            pos1 = start;
            pos2 = BatteryPos;
            cutSceneCam.transform.LookAt(BatteryLook);
            lerp();
        }
        if (Slot)
        {
            pos1 = BatteryPos;
            pos2 = SlotPos;
            cutSceneCam.transform.LookAt(SlotLook);
            lerp();
        }
        if (Gun)
        {
            pos1 = SlotPos;
            pos2 = GunPos;
            cutSceneCam.transform.LookAt(GunLook);
            lerp();
        }
        if (Escape)
        {
            pos1 = GunPos;
            pos2 = EscapePos;
            cutSceneCam.transform.LookAt(EscapeLook);
            lerp();
        }
    }

    private void lerp()
    {
        lerpTimer += Time.deltaTime * smooth;
        cutSceneCam.transform.position = Vector3.Lerp(pos1.position, pos2.position, lerpTimer);

        if (lerpTimer >= 1)
        {
            if (battery)
            {
                battery = false;
                Slot = true;
            }
            else if (Slot)
            {
                Slot = false;
                Gun = true;
            }
            else if (Gun)
            {
                Gun = false;
                Escape = true;
            }
            else if (Escape)
            {
                Escape = false;
                rayCastScript.startScript();
                LerpBetweenCameras.Instance.LerpCameras(cutSceneCam, mainCam);
            }
            lerpTimer = 0;
        }
    }
}

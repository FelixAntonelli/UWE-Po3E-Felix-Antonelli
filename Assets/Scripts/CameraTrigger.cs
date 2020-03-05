using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;
    public float x;
    public float y = 2;
    public float z = 5;
    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    private float start_x;
    private float start_y;
    private float start_z;
    private float lerp_timer;
    public float smooth;
    private Vector3 cam_pos;
   private float move_x;
    private float move_y;
    private float move_z;

    private void Awake()
    {
        liveCam = Camera.allCameras[0];
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider)
        {
            /// Vector3 moveCam = new Vector3(liveCam.transform.localPosition.x, liveCam.transform.localPosition.y + y, liveCam.transform.localPosition.z - z);
            /// moveCam = liveCam.transform.TransformDirection(moveCam);
            ///liveCam.transform.localPosition = moveCam;
            start_x = liveCam.transform.localPosition.x;
            start_y = liveCam.transform.localPosition.y;
            start_z = liveCam.transform.localPosition.z;
            move_x *= Time.deltaTime;
            move_y *= Time.deltaTime;
            move_z *= Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            ///Vector3 moveCam = new Vector3(liveCam.transform.localPosition.x, liveCam.transform.localPosition.y - y, liveCam.transform.localPosition.z + z);
           /// liveCam.transform.localPosition = moveCam;
        }
    }
    private void Update()
    {
        zoom();
    }
    private void zoom()
    {
        lerp_timer = Time.deltaTime * smooth;
        cam_pos.x = Mathf.Lerp(liveCam.transform.localPosition.x, liveCam.transform.localPosition.x - move_x, lerp_timer);
        cam_pos.y = Mathf.Lerp(liveCam.transform.localPosition.y, liveCam.transform.localPosition.y + move_y, lerp_timer);
        cam_pos.z = Mathf.Lerp(liveCam.transform.localPosition.z, liveCam.transform.localPosition.z - move_z, lerp_timer);
        liveCam.transform.localPosition = cam_pos;
    }
}

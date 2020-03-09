using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera liveCam;
    public Transform new_pos;
    private bool trigger = false;
    private bool trigger_exit = false;
    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    private float lerp_timer;
    public float smooth;
    private Vector3 cam_pos;
    private Vector3 start_pos;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider)
        {
            start_pos = liveCam.transform.localPosition;
            trigger = true;
            lerp_timer = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            trigger = false;
            trigger_exit = true;
            lerp_timer = 0;
        }
    }
    private void FixedUpdate()
    {
        zoom();
    }
    private void zoom()
    {
        if (trigger)
        {
            //Vector3 player_chest = PlayerCharacter.transform.position;
            //player_chest.y = player_chest.y + 2;
            lerp_timer += Time.deltaTime * smooth;
            cam_pos = Vector3.Lerp(start_pos, new_pos.localPosition, lerp_timer);
            //liveCam.transform.LookAt(player_chest);
            liveCam.transform.localPosition = cam_pos;
        }
        else if (trigger_exit)
        {
            //Vector3 player_chest = PlayerCharacter.transform.position;
            //player_chest.y = player_chest.y + 2;
            lerp_timer += Time.deltaTime * (smooth * 2);
            cam_pos = Vector3.Lerp(new_pos.localPosition, start_pos, lerp_timer);
            //liveCam.transform.LookAt(player_chest);
            liveCam.transform.localPosition = cam_pos;
        }
        
    }
}
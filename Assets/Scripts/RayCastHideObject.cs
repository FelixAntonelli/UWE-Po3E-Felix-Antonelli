﻿using System.Collections.Generic;
using UnityEngine;

public class RayCastHideObject : MonoBehaviour
{
    private Ray ray;
    public Transform camera_transform;
    public Transform player_transform;
    public Transform camera_start_transform;
    public Transform POV_transform;
    public LayerMask layerMask = Physics.AllLayers;
    public float sphereCastSize = 1;
    private float distance;
    public Camera mainCam;
    private float lerpTimer;
    public float smooth;
    private bool stop = true;
    //TODO: create ray
    // update ray
    //raycast
    // Start is called before the first frame update
    void Start()
    {
        setupRay();
    }

    void moveByLerp(Vector3 cameraCurrent, Vector3 new_pos)
    {
        lerpTimer += Time.deltaTime * smooth;
        camera_transform.localPosition = Vector3.Lerp(cameraCurrent, new_pos, lerpTimer);
        
        if (cameraCurrent == new_pos)
        {
            lerpTimer = 0;
        }
    }
    private void OnDrawGizmos()
    {
        setupRay();
        Gizmos.DrawWireSphere(camera_transform.position, sphereCastSize);
        Gizmos.DrawRay(ray);
    }
    private void setupRay()
    {
        ray.origin = (player_transform.position + new Vector3(0, 0, 0));
        ray.direction = camera_transform.position - (player_transform.position + new Vector3(0, 0.8f, 0));
        distance = Vector3.Distance(camera_start_transform.position, player_transform.position + new Vector3(0, 0.8f, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            setupRay();
            if (Physics.SphereCast(ray, sphereCastSize, out RaycastHit hit, distance))
            {
                if (!(hit.collider.tag == "IgnoreRayCast" || hit.collider.tag == "Player"))
                {
                    if (distance - hit.distance < 0.1)
                    {
                        Debug.Log("Distance is less than 0.1");
                        moveByLerp(camera_transform.localPosition, new Vector3(0, 0, 0.1f));
                    }
                    else
                    {
                        moveByLerp(camera_transform.localPosition, new Vector3(0, 0, distance - hit.distance));
                    }
                }
            }
            else
            {
                camera_transform.position = camera_start_transform.position;
            }
        }
      
    }
    public void stopScript()
    {
        stop = true;
    }
    public void startScript()
    {
        stop = false;
    }        
}

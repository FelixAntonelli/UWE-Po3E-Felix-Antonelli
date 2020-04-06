using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOutOfBasket : MonoBehaviour
{

    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    private Animator animator;
    private GameObject enviro;

    public Transform playerTransform;
    public Camera basketCam;
    public Camera mainCam;
    public RayCastHideObject rayCastScript;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        enviro = GameObject.FindGameObjectWithTag("Enviroment");
        animator = enviro.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollider)
        {
            if (Input.GetButtonDown("Interact"))
            {
                LerpBetweenCameras.Instance.LerpCameras(basketCam, mainCam);
                rayCastScript.startScript();
                playerTransform.parent = null;
                playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - 0.5f);
            }
        }
    }
}

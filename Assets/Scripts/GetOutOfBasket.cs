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
            if (Input.GetButton("Interact"))
            {
                playerTransform.parent = null;
                playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z - 5);
            }
        }
    }
}

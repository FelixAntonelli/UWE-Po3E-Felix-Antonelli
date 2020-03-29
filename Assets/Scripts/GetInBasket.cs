using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInBasket : MonoBehaviour
{
    public Transform playerTransform;
    public Transform basketTransform;
    private Animator animator;
    private GameObject enviro;
    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
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
                playerTransform.parent = basketTransform;
                playerTransform.localPosition = new Vector3(0,0,0);
                animator.SetBool("startAnim", true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            animator.SetBool("startAnim", false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketStopAndStart : MonoBehaviour
{
    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    private Animator animator;
    private GameObject enviro;
    private float timer = 0;
    private bool end = false;

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        enviro = GameObject.FindGameObjectWithTag("Enviroment");
        animator = enviro.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollider && !end)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                animator.speed = 0;
                if (Input.GetButton("Jump"))
                {
                    animator.speed = 1;
                    end = true;
                }
            }
        }
    }
}

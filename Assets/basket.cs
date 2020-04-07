using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : StateMachineBehaviour
{
    public ParticleSystemRenderer pRenderer;

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
        pRenderer.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollider && !end)
        {

            if (timer < 3.5f)
            {
                animator.speed = 0;
                if (Input.GetButton("Interact"))
                {
                    animator.speed = 1;
                    pRenderer.enabled = true;
                    timer += Time.deltaTime;
                }
                else
                {
                    animator.speed = 0;
                }
            }
            else
            {
                animator.speed = 1;
                pRenderer.enabled = false;
            }
        }
    }
    void basketBreak()
    {
        Debug.Log("Basket Break");
    }
}



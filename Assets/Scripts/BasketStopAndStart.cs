﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketStopAndStart : MonoBehaviour
{
    public ParticleSystemRenderer pRenderer;

    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    private Animator animator;
    private GameObject enviro;
    private float timer = 0;
    private bool broke = false;
    

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        enviro = GameObject.FindGameObjectWithTag("Enviroment");
        animator = enviro.GetComponent<Animator>();
        pRenderer.enabled = false;
    }

    private void Update()
    {
        if (broke)
        {
            if (timer < 2)
            {

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
    void BasketBreak()
    {
        if (!broke)
        {
            animator.speed = 0;
            broke = true;
        }
    }
}

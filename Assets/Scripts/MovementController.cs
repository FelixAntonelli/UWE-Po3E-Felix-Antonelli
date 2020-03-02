using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MovementController : MonoBehaviour
{

    private Animator anim;
    private new Rigidbody rigidbody;
    public float speed = 1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        anim.SetBool("WalkForward", Input.GetButton("Forwards"));

        anim.SetBool("TurnLeft", Input.GetButton("Left"));

        anim.SetBool("TurnRight", Input.GetButton("Right"));

        anim.SetBool("WalkBackwards", Input.GetButton("Backwards"));
    }
    private void MovementManager(bool forwards, bool backwards, bool left, bool right)
    {
        anim.SetBool(Animator.StringToHash("WalkForward"), forwards);
        ///anim.SetBool(Animator.StringToHash("WalkBackwards"), backwards);
        anim.SetBool(Animator.StringToHash("TurnLeft"), left);
        anim.SetBool(Animator.StringToHash("TurnRight"), right);
    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Backwards"))
        {
            Vector3 moveBack = new Vector3(0, 0, -0.015f);
            moveBack = rigidbody.transform.TransformDirection(moveBack);
            rigidbody.transform.position += moveBack;
        }
    }
}

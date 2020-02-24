using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class MovementController : MonoBehaviour
{

    private Animator anim;
    private new Rigidbody rigidbody;


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


        //bool forwards = Input.GetButton("Forwards");
        //bool backwards = Input.GetButton("Backwards");
        //bool left = Input.GetButton("Left");
        //bool right = Input.GetButton("Right");
        //MovementManager(forwards, backwards, left, right);
    }
    private void MovementManager(bool forwards, bool backwards, bool left, bool right)
    {
        anim.SetBool(Animator.StringToHash("WalkForward"), forwards);
        ///anim.SetBool(Animator.StringToHash("WalkBackwards"), backwards);
        anim.SetBool(Animator.StringToHash("TurnLeft"), left);
        anim.SetBool(Animator.StringToHash("TurnRight"), right);
    }
}

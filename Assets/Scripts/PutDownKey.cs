using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownKey : MonoBehaviour
{
    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    public Transform leverTransform;
    public Transform slotTransform;
    public Transform playerTransform;
    public Light light;
    private Animator animator;
    private GameObject enviro;

    // Start is called before the first frame update
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
                if (leverTransform.parent == playerTransform)
                {
                    leverTransform.parent = slotTransform;
                    leverTransform.localPosition = new Vector3(0,0,0);
                    leverTransform.localRotation = new Quaternion(0,0,0,0);
                    leverTransform.localScale = new Vector3(0.2f,0.2f,0.2f);
                    animator.SetBool("readyAnim", true);
                    light.color = Color.green;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

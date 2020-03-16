using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    private bool on_ground = true;
    public Transform leverTransform;
    public Transform playerTransform;
    public Transform slotTransform;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollider)
        {
            if (Input.GetButton("Interact"))
            {
                if (on_ground)
                {
                    leverTransform.parent = playerTransform;
                    leverTransform.localPosition = new Vector3(0, 0.1f, 0.0f);
                    on_ground = false;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    
}

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
                if (leverTransform.parent == playerTransform)
                {
                    leverTransform.parent = slotTransform;
                    leverTransform.localPosition = new Vector3(0, 0.0f, -0.5f);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

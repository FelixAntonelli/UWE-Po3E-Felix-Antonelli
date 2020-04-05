using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerDropShips : MonoBehaviour
{
    public GameObject DropShip1;
    public GameObject DropShip2;
    public GameObject DropShip1End;
    public GameObject DropShip2End;

    private Transform DropShip2Start;
    private Transform DropShip1Start;
    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    private bool lerp = false;
    private bool triggered = false;
    private float lerpTimer = 0;
    private float smooth = 0.001f;
    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        DropShip1Start = DropShip1.transform;
        DropShip2Start = DropShip2.transform;
        DropShip1.SetActive(false);
        DropShip2.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            if (!triggered)
            {
                lerp = true;
                triggered = true;
                DropShip1.SetActive(true);
                DropShip2.SetActive(true);
            }
            
        }
    }
    private void Update()
    {
        if (lerp)
        {
            lerpTimer += Time.deltaTime * smooth;
            DropShip1.transform.position = Vector3.Lerp(DropShip1Start.transform.position, DropShip1End.transform.position, lerpTimer);
            DropShip2.transform.position = Vector3.Lerp(DropShip2Start.transform.position, DropShip2End.transform.position, lerpTimer);

            if (lerpTimer >= 1)
            {
                lerp = false;
            }
        }
    }
}

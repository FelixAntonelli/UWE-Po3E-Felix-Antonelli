using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    private GameObject PlayerCharacter;
    public Camera liveCam;
    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Vector3 player_chest = PlayerCharacter.transform.position;
        player_chest.y = player_chest.y + 2;
        liveCam.transform.LookAt(player_chest);
    }

}

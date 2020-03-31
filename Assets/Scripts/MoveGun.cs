using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    public Transform BarrelTransform;
    public Transform GunTransform;

    private void FixedUpdate()
    {
        if (Input.GetButton("AimUp"))
        {
            BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z - 0.005f, BarrelTransform.localRotation.w);
        } else if (Input.GetButton("AimDown"))
        {
            BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z + 0.005f, BarrelTransform.localRotation.w);
        }
        if (BarrelTransform.localRotation.z > 0.065f)
        {
            BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, 0.065f, BarrelTransform.localRotation.w);
        }
        if (BarrelTransform.localRotation.z < -0.4f)
        {
            BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, -0.4f, BarrelTransform.localRotation.w);
        }

        if (Input.GetButton("AimLeft"))
        {
            BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x - 0.005f, BarrelTransform.localRotation.y,BarrelTransform.localRotation.z, BarrelTransform.localRotation.w);
            GunTransform.localRotation = new Quaternion(GunTransform.localRotation.x, GunTransform.localRotation.y - 0.005f, GunTransform.localRotation.z, GunTransform.localRotation.w);
        }
        else if (Input.GetButton("AimRight"))
        {
            BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x + 0.005f, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z, BarrelTransform.localRotation.w);
            GunTransform.localRotation = new Quaternion(GunTransform.localRotation.x , GunTransform.localRotation.y + 0.005f, GunTransform.localRotation.z, GunTransform.localRotation.w);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

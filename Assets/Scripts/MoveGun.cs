using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    public Transform BarrelTransform;
    public Transform GunTransform;
    public Camera playerCam;
    public Camera gunCam;
    public Transform EndOfBarrelTransform;
    public Transform returnPos;
    public SkinnedMeshRenderer meshRenderer;
    public float smooth = 2f;
    public ParticleSystem particles;

    private GameObject PlayerCharacter;
    private Collider PlayerCollider;
    private bool on_gun = false;
    public RayCastHideObject RayCastHideObject;
    private Vector3 intialPos;
    
    private Quaternion intialRotate;
    private float particleSpeed;
    private float particleDist;
    private float particleBrightness = 3;
    

    private void Awake()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerCollider = PlayerCharacter.GetComponent<Collider>();
        particles.enableEmission = false;
        particleSpeed = particles.main.simulationSpeed;
        particleDist = particles.velocityOverLifetime.x.constant;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollider)
        {
            if (Input.GetKeyDown(KeyCode.G) && !on_gun)
            {
                Debug.Log("Mountgun was pressed");
                LerpBetweenCameras.Instance.LerpCameras(playerCam, gunCam);
                on_gun = true;
                RayCastHideObject.stopScript();
            }
            else if (Input.GetKeyDown(KeyCode.G) && on_gun)
            {
                LerpBetweenCameras.Instance.LerpCameras(gunCam, playerCam);
                on_gun = false;
                RayCastHideObject.startScript();
            }
        }
    }

    private void FixedUpdate()
    {
        if (on_gun)
        {
            if (Input.GetButton("AimUp"))
            {
                BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z - 0.005f, BarrelTransform.localRotation.w);

            }
            else if (Input.GetButton("AimDown"))
            {
                BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z + 0.005f, BarrelTransform.localRotation.w);
            }
            if (BarrelTransform.localRotation.z > 0.065f)
            {
                BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, 0.065f, BarrelTransform.localRotation.w);
            }
            if (BarrelTransform.localRotation.z < -0.3f)
            {
                BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, -0.3f, BarrelTransform.localRotation.w);
            }

            if (Input.GetButton("AimLeft"))
            {
                BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x - 0.005f, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z, BarrelTransform.localRotation.w);
            }
            else if (Input.GetButton("AimRight"))
            {
                BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x + 0.005f, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z, BarrelTransform.localRotation.w);
            }
            if (BarrelTransform.localRotation.x > 0.22)
            {
                BarrelTransform.localRotation = new Quaternion(0.22f, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z, BarrelTransform.localRotation.w);
            }
            if (BarrelTransform.localRotation.x < -0.06)
            {
                BarrelTransform.localRotation = new Quaternion(-0.06f, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z, BarrelTransform.localRotation.w);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (on_gun)
        {
            gunCam.transform.LookAt(EndOfBarrelTransform);
            meshRenderer.enabled = false;
            ParticleSystem.MainModule psMain = particles.main;
            ParticleSystem.VelocityOverLifetimeModule psVelocity = particles.velocityOverLifetime;
            ParticleSystem.Particle[] p = new ParticleSystem.Particle[particles.particleCount + 1];
            ParticleSystem.LightsModule psLight = particles.lights;
            particles.enableEmission = true;
            if (Input.GetButton("Fire"))
            {
                particleDist -= 10 * Time.deltaTime;
                particleSpeed += 0.5f * Time.deltaTime;
                particleBrightness += 1 * Time.deltaTime;
                if (particleSpeed > 1)
                {
                    particleSpeed = 1;
                }
                if (particleBrightness > 8)
                {
                    particleBrightness = 8;
                }
                BarrelTransform.localRotation = new Quaternion(BarrelTransform.localRotation.x, BarrelTransform.localRotation.y, BarrelTransform.localRotation.z - 0.0005f, BarrelTransform.localRotation.w);
            }
            else
            {
                particleDist = -5;
                particleSpeed = 0.1f;
                particleBrightness = 3;
            }

            int l = particles.GetParticles(p);

            int i = 0;
            while (i < l)
            {
                p[i].velocity = new Vector3(particleDist, 0, 0);
                i++;
            }
            particles.SetParticles(p, l);
            psMain.simulationSpeed = particleSpeed;
            psLight.intensityMultiplier = particleBrightness;
            psLight.rangeMultiplier = particleBrightness;
        }
        else if (!on_gun)
        {
            meshRenderer.enabled = true;
        }
    }
}

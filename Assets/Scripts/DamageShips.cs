using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShips : MonoBehaviour
{
    public GameObject DropShip1;
    public GameObject DropShip2;
    public ParticleSystem Ship1Particles;
    public ParticleSystem Ship2Particles;
    public ParticleSystemRenderer ship1PRenderer;
    public ParticleSystemRenderer ship2PRenderer;
    public Rigidbody ship1Body;
    public Rigidbody ship2Body;

    private Collider _ship1Collider;
    private Collider _ship2Collider;
    private float _ship1Health = 500;
    private float _ship2Health = 500;
    private float ship1Timer = 0;
    private float ship2Timer = 0;
    private ParticleSystem.MainModule _ship1Main;
    private ParticleSystem.MainModule _ship2Main;


    private void Awake()
    {
        _ship1Collider = DropShip1.GetComponent<MeshCollider>();
        _ship2Collider = DropShip2.GetComponent<MeshCollider>();
        _ship1Main = Ship1Particles.main;
        _ship2Main = Ship2Particles.main;
    }

    private void Update()
    {
        float temp;
        if (_ship1Health < 150)
        {
            ship1PRenderer.enabled = true;
            temp = _ship1Main.startSize.constant;
            temp += 5 * Time.deltaTime;
            _ship1Main.startSize = temp;
        }
        if (_ship1Health < 0)
        {
            temp = _ship1Main.startSize.constant;
            temp -= 15 * Time.deltaTime;
            _ship1Main.startSize = temp;
            ship1Timer += Time.deltaTime;
        }
        if (ship1Timer > 2)
        {
            ship1PRenderer.enabled = false;
        }


        if (_ship2Health < 150)
        {
            ship2PRenderer.enabled = true;
            temp = _ship2Main.startSize.constant;
            temp += 5 * Time.deltaTime;
            _ship2Main.startSize = temp;
        }
        if (_ship2Health < 0)
        {
            temp = _ship2Main.startSize.constant;
            temp -= 15 * Time.deltaTime;
            _ship2Main.startSize = temp;
            ship2Timer += Time.deltaTime;
        }
        if (ship2Timer > 2)
        {
            ship2PRenderer.enabled = false;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other == DropShip1)
        {
            _ship1Health -= 10;
            if (_ship1Health < 0)
            {
                ship1Body.isKinematic = false;
                ship1Body.useGravity = true;
                ship1Body.velocity = new Vector3(-10,0,0);
            }
        }
        if (other == DropShip2)
        {
            _ship2Health -= 10;
            if (_ship2Health < 0)
            {
                ship2Body.isKinematic = false;
                ship2Body.useGravity = true;
                ship2Body.velocity = new Vector3(-10, -5, 0);
            }
        }
    }

}

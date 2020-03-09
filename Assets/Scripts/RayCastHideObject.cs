using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHideObject : MonoBehaviour
{
    private Ray ray;
    public Transform camera_transform;
    public Transform player_transform;
    private List<Renderer> renderers = new List<Renderer>();
    public LayerMask layerMask = Physics.AllLayers;
    private RaycastHit[] previousHits;
    //TODO: create ray
    // update ray
    //raycast
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = camera_transform.position;
        ray.direction = player_transform.position - camera_transform.position;

        RaycastHit[] hits;
        hits = Physics.SphereCastAll(ray, 1, Vector3.Distance(player_transform.position, camera_transform.position), layerMask);
        bool already_exist = false;
        foreach (var prevHit in previousHits)
        {
            var prevRenderer = prevHit.collider.GetComponent<Renderer>();
            var renderer = new Renderer();
            if (prevRenderer == null)
            {
                continue;
            }
            foreach (var hit in hits)
            {
                renderer = hit.collider.GetComponent<Renderer>();
                if (renderer == null)
                {
                    continue;
                }
                if (prevRenderer == renderer)
                {
                    already_exist = true;
                }
            }
            if (!already_exist)
            {
                renderer.enabled = false;

            }
        }

        foreach (var hit in hits)
        {
            var renderer = hit.collider.GetComponent<Renderer>();
            if (renderer == null)
            {
                continue;
            }
            if (renderers.Contains(renderer))
            {
                continue;
            }
            renderer.enabled = false;
            renderers.Add(renderer);
        }
        previousHits = hits;
        
    }
}

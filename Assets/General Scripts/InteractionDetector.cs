using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    public string interactible_tag;
    public string interaction_message = "trigger";
    public float interaction_distance = Mathf.Infinity;
    public LayerMask ignoreLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        ignoreLayer = ~ignoreLayer;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interaction_distance, ignoreLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (Input.GetKeyDown("e"))
            {
                if (hit.collider.tag == interactible_tag)
                {
                    hit.collider.SendMessageUpwards("trigger", this.gameObject);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectreInteraction : MonoBehaviour
{
    public Camera cam;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        Display.displays[1].Activate();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        var positioN = transform.position;
        positioN.y += 0.8f;
        ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetKey("e"))
                if (hit.collider.tag == "P1_Button")
                    hit.collider.gameObject.SendMessageUpwards("pressButton");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
}

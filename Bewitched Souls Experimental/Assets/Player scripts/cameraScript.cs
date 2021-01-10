using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public List<Light> Lights;
    public bool cullLights = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPreCull()
    {
        if (cullLights == true)
        {
            foreach (Light light in Lights)
            {
                light.enabled = false;
            }
        }
    }

    void OnPostRender()
    {
        if (cullLights == true)
        {
            foreach (Light light in Lights)
            {
                light.enabled = true;
            }
        }
    }
}

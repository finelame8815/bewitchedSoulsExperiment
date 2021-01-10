using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    public GameObject _object;
    public float Timer;
    private float time_left = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time_left > 0)
            time_left -= Time.deltaTime;
        else if (time_left < 0)
        {
            if (Timer != -1)
                _object.SendMessageUpwards("trigger", false);
            time_left = 0;
        }
    }

    void trigger()
    {
        if (time_left == 0)
        {
            _object.SendMessageUpwards("trigger", true);
            time_left = Timer;
        }
    }
}

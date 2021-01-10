using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressure_plate : MonoBehaviour
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _object.SendMessageUpwards("trigger", true);
            time_left = Timer;
        }
    }
}

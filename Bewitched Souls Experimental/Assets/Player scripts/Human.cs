using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1button : MonoBehaviour
{
    public GameObject door;
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
                door.SendMessageUpwards("updateState", false);
            time_left = 0;
            Debug.Log("Unpressed");
        }
    }

    void pressButton()
    {
        if (time_left == 0)
        {
            Debug.Log("pressed");
            door.SendMessageUpwards("updateState", true);
            time_left = Timer;
        }
    }
}

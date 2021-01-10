using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float open_position = -1.7f;
    public float closed_position = 1.5f;
    public bool _state = false;
    private Vector3 speed;
    public float opening_speed;
    public float closing_speed;
    public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_state)
        {
            if (transform.position.y > open_position) {
                speed.Set(0f, -1f * opening_speed, 0f);
                body.velocity = speed;
            }
            else
            {
                stopDoor();
            }
        }
        else
        {
            if (transform.position.y < closed_position)
            {
                speed.Set(0f, 2f * closing_speed, 0f);
                body.velocity = speed;
            }
            else
            {
                stopDoor();
            }
        }
    }

    void stopDoor()
    {
        speed.Set(0f, 0f, 0f);
        body.velocity = speed;
    }

    void updateState(bool state)
    {
        _state = state;
    }
}

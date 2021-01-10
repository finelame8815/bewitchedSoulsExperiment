using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanJump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<CharacterController>().Move(Vector3.up * jumpVelocity);
        }
    }
}

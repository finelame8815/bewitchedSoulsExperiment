using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_detector : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerMove>().isGrounded = true;
    }

    private void OnTriggerStay(Collider other)
    {
        player.GetComponent<PlayerMove>().isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerMove>().isGrounded = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public Canvas can;
    public Canvas can2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collisionInfo)

    {
        if (collisionInfo.gameObject.tag == "Player" || collisionInfo.gameObject.tag == "Specter")
        {
            Debug.Log("mmmmmh");
            can.gameObject.SetActive(true);
            can2.gameObject.SetActive(true);
        }
    }
}

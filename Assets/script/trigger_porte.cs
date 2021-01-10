using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_porte : MonoBehaviour
{
    public int distance = 100;
    public AudioSource source;
    private bool open = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void trigger(bool stat)
    {
        Vector3 Xmove = new Vector3(distance, 0, 0);
        if (stat)
        {
            if (open == false) {
                source.Play();
                open = true;
            }
            this.gameObject.GetComponent<Transform>().Translate(Xmove);
        }
        else
        {
            this.gameObject.GetComponent<Transform>().Translate(-Xmove);
        }
    }
}

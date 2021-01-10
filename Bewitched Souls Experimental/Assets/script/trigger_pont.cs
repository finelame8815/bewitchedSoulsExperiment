using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_pont : MonoBehaviour
{
    public int angle = 47;
    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    void trigger(bool stat)
    {
        Vector3 Xrotate = new Vector3(angle, 0, 0);
        Vector3 init = new Vector3(0, 0, 0);

        if (stat) {
            source.Play();
            this.gameObject.GetComponent<Transform>().eulerAngles = Xrotate;
        } else {
            source.Play();
            this.gameObject.GetComponent<Transform>().eulerAngles = init;
        }
    }
}

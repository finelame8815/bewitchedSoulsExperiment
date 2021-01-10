using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancre : MonoBehaviour
{
    public GameObject tp_point;
    public bool isAnchor = true;
    public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void trigger(GameObject obj) {
        source.Play();
        obj = obj.transform.parent.gameObject.transform.parent.gameObject;
        obj.transform.position = tp_point.transform.position;
        obj.GetComponent<PlayerMove>().setAnchor(this.gameObject, isAnchor);
    }
}

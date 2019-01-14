using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_collide : MonoBehaviour
{

    public bool canrotate;
    // Use this for initialization
    void Start()
    {
        canrotate = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Gun")
        {
            canrotate = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Gun")
        {
            canrotate = true;
        }
    }
}

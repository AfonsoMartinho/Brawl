using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_fall : MonoBehaviour
{

    public bool p1Falls;
    public bool p2Falls;
    GameObject manager;
    Manager main;

    // Use this for initialization
    void Start()
    {
        p1Falls = false;
        p2Falls = false;
        //recebe o objeto que contem o script manager
        manager = GameObject.Find("Manager");

        //recebe o script manager
        main = manager.GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray endRay = new Ray(transform.position, new Vector3(0, 0, 1));
        if (Physics.Raycast(endRay, out hit))
        {
            //Se o p1 passa pelo ray perde 1 vida
            if (hit.collider.gameObject.name == "Player1")
            {
                p1Falls = true;
               

            }
            //Se o p2 passa pelo ray perde 1 vida
            if (hit.collider.gameObject.name == "Player2")
            {
                p2Falls = true;
                
            }
        }
    }
}

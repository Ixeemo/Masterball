using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovePillars : MonoBehaviour
{
    //29,4
    public GameObject bramka1;
    public float speed;
    public bool right, left;
    //private Transform target;
    /*
    void Awake()
    {
        // Position the cube at the origin.
        transform.position = new Vector3(9.7f, 1.9f, -39.6f);

        // Grab cylinder values and place on the target.
        target = bramka1.transform;
        target.transform.localScale = new Vector3(0.15f, 1.0f, 0.15f);
        target.transform.position = new Vector3(0.8f, 0.0f, 0.8f);

        // Create and position the floor.
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(0.0f, -1.0f, 0.0f);
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //
        if (bramka1.transform.position.x >= 22.37f)
        {
            right = false;
            //bramka1.transform.position -= Vector3.left * Time.deltaTime * speed;
        }
        else if (bramka1.transform.position.x <= -12.87f)
        {
            right = true;
        }
        
        if (right == true)
        {
            bramka1.transform.position -= Vector3.left * Time.deltaTime * speed;
        }

        if (right == false)
        {
            bramka1.transform.position += Vector3.left * Time.deltaTime * speed;
        }

    }

}

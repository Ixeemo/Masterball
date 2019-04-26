using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveObject : MonoBehaviour
{   

    public Rigidbody item;
    public GameObject tempParent;
    public GameObject Autobot;
    public float moveSpeed;
    public bool isSpace;
    public bool inRange;
    

    // Start is called before the first frame update
    
    public void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {  

            isSpace = false;
            inRange = false; 
            
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.AddForce(0, 0, -moveSpeed, ForceMode.Impulse);
            
            
        }
            
    }
    

    
     
    void Start()
    {
        item = GetComponent<Rigidbody>();
        item.GetComponent<Rigidbody>().useGravity = true;
        isSpace = false;
        inRange = false;
        
    }

    // Update is called once per frame
    void Update()
    {   
        /*
        if (Input.GetKeyDown("space") && isSpace == true)
        {   
            isSpace = false;
            
        }

        
        if (isSpace == false)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            
            //item.transform.parent = tempParent.transform;
        }
        */

        if ((Input.GetKeyDown("space") && isSpace == false) && inRange == true)
        {
            isSpace = true;
            
        }

        if (Math.Abs(item.transform.position.x - Autobot.transform.position.x) <=  1.55f && Math.Abs(item.transform.position.z - Autobot.transform.position.z) <= 1.55f)
        {
            inRange = true;
        }
        else { inRange = false; } 


        if (isSpace == true && inRange == true)
        {

            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = new Vector3(Autobot.transform.position.x, Autobot.transform.position.y + 0.1f, Autobot.transform.position.z - 1.25f);

            Shoot();           
            //item.transform.parent = tempParent.transform;
        }


    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

 public float moveSpeed;
 public GameObject autoBot;
 

    // Use this for initialization
    void Start () 
 {
      
 }
 
 // Update is called once per frame
 void FixedUpdate () 
 {  
    //rigidbody.isKinematic = false;
    autoBot.transform.Translate(moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime, -moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f); 
 }

void OnCollisionEnter(Collision collision) 
 {
         
 }
 
}﻿
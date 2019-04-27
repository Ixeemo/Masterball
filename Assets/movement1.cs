using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement1 : MonoBehaviour {

 public float moveSpeed;

 // Use this for initialization
 void Start () 
 {
  
 }
 
 // Update is called once per frame
 void Update () 
 {
  transform.Translate(-moveSpeed*Input.GetAxis("Vertical1")*Time.deltaTime,moveSpeed*Input.GetAxis("Horizontal1")*Time.deltaTime, 0f); 
 }
}﻿
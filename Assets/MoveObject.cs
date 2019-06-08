﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveObject : MonoBehaviour
{   

    public Rigidbody item;
    public GameObject tempParent;
    public GameObject Autobot;
    public GameObject Autobot1;
    public float moveSpeed;
    public bool isO;
    public bool isSpace;
    public bool inRange;
    public bool inRange1;
    public int counter;
    public int counter1;
    public Text countText;
    public AudioClip GoalClip;
    public AudioSource GoalSource;
    public AudioClip ShotClip;
    public AudioSource ShotSource;
    

    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bramka")
        {
            
                counter ++;
                if (counter >= 10)
                {
                    counter = 0;
                }
                PlayerPrefs.SetInt("High Score", counter);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
                //Destroy(other);
                SetCountText();
                GoalSource.Play();

        }

        if (other.gameObject.tag == "bramka1")
        {   
            
                counter1 ++;
                if (counter1 >= 10)
                {
                    counter1 = 0;
                }
                PlayerPrefs.SetInt("High Score 1", counter1);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
                //Destroy(other);
                SetCountText();
                GoalSource.Play();
        }
    }

    void SetCountText()
    {
        countText.text = "Wynik " + PlayerPrefs.GetInt("High Score").ToString() + ":" + PlayerPrefs.GetInt("High Score 1").ToString();
    }
    
    public void Shoot()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {  

            isO = false;
            inRange = false; 
            
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.AddForce(0, 0, -moveSpeed, ForceMode.Impulse);
            ShotSource.Play();
            
            
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {  

            isSpace = false;
            inRange1 = false; 
            
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.AddForce(0, 0, moveSpeed, ForceMode.Impulse);
            ShotSource.Play();
        }    
    }
    

    
     
    void Start()
    {
        item = GetComponent<Rigidbody>();
        item.GetComponent<Rigidbody>().useGravity = true;
        isO = false;
        isSpace = false;
        inRange1 = false;
        inRange = false;
        counter = PlayerPrefs.GetInt("High Score");
        counter1 = PlayerPrefs.GetInt("High Score 1");
        SetCountText();
        GoalSource.clip = GoalClip;
        ShotSource.clip = ShotClip;
        
    }

    void Awake(){
        DontDestroyOnLoad(GoalClip);
        DontDestroyOnLoad(GoalSource);
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Rotate(new Vector3(0f, Time.deltaTime * 60, 0f), Space.World);
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

        if ((Input.GetKeyDown(KeyCode.O) && isO == false) && inRange == true)
        {
            isO = true;
            
        }

        if (Math.Abs(item.transform.position.x - Autobot.transform.position.x) <=  1.6f && Math.Abs(item.transform.position.z - Autobot.transform.position.z) <= 3.0f)
        {
            inRange = true;
        }
        else { inRange = false; } 


        if (isO == true && inRange == true)
        {

            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = new Vector3(Autobot.transform.position.x, Autobot.transform.position.y + 0.1f, Autobot.transform.position.z - 2.7f);
            isSpace = false;

            Shoot();           
            //item.transform.parent = tempParent.transform;
        }

        // drugi gracz:
        if ((Input.GetKeyDown(KeyCode.Space) && isSpace == false) && inRange1 == true)
        {
            isSpace = true;
            
        }

        if (Math.Abs(item.transform.position.x - Autobot1.transform.position.x) <=  1.6f && Math.Abs(item.transform.position.z - Autobot1.transform.position.z) <= 3.0f)
        {
            inRange1 = true;
        }
        else { inRange1 = false; } 


        if (isSpace == true && inRange1 == true)
        {

            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = new Vector3(Autobot1.transform.position.x, Autobot1.transform.position.y + 0.1f, Autobot1.transform.position.z + 2.7f);
            isO = false;

            Shoot();           
            //item.transform.parent = tempParent.transform;
        }


    }

    
}

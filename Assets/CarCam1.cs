﻿using UnityEngine;

public class CarCam1 : MonoBehaviour
{
    Transform rootNode;
    Transform carCam;
    private GameObject Autobot1;
    Rigidbody carPhysics;

    [Tooltip("If car speed is below this value, then the camera will default to looking forwards.")]
    public float rotationThreshold = 1f;

    [Tooltip("How closely the camera follows the car's position. The lower the value, the more the camera will lag behind.")]
    public float cameraStickiness = 10.0f;

    [Tooltip("How closely the camera matches the car's velocity vector. The lower the value, the smoother the camera rotations, but too much results in not being able to see where you're going.")]
    public float cameraRotationSpeed = 5.0f;

    void Awake()
    {
        carCam = Camera.main.GetComponent<Transform>();
        rootNode = GetComponent<Transform>();
        //car = rootNode.parent.GetComponent<Transform>();
        if (PlayerPrefs.GetInt("CharacterSelected") == 0)
        {
            Autobot1 = GameObject.Find("/modelList/SpaceShuttleGreen/AutobotGreen1");
        }
        else if (PlayerPrefs.GetInt("CharacterSelected") == 1)
        {
            Autobot1 = GameObject.Find("/modelList/SpaceShuttleBlue/AutobotBlue1");
        }
        else if (PlayerPrefs.GetInt("CharacterSelected") == 2)
        {
            Autobot1 = GameObject.Find("/modelList/SpaceShuttleOrange/AutobotOrange1");
        }
        else
        {
            Autobot1 = GameObject.Find("/modelList/SpaceShuttleRed/AutobotRed1");
        }
        carPhysics = Autobot1.GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Detach the camera so that it can move freely on its own.
        rootNode.parent = null;
    }

    void FixedUpdate()
    {
        Quaternion look;

        // Moves the camera to match the car's position.
        rootNode.position = Vector3.Lerp(rootNode.position, Autobot1.transform.position, cameraStickiness * Time.fixedDeltaTime);

        // If the car isn't moving, default to looking forwards. Prevents camera from freaking out with a zero velocity getting put into a Quaternion.LookRotation
        if (carPhysics.velocity.magnitude < rotationThreshold)
            look = Quaternion.LookRotation(Autobot1.transform.forward);
        else
            look = Quaternion.LookRotation(Autobot1.transform.forward);

        // Rotate the camera towards the velocity vector.
        look = Quaternion.Slerp(rootNode.rotation, look, cameraRotationSpeed * Time.fixedDeltaTime);
        rootNode.rotation = look;
    }
}
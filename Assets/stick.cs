using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stick : MonoBehaviour
{
    public Rigidbody item;
    public Rigidbody ship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        item.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, ship.transform.position.z);
    }
}

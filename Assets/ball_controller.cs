using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_controller : MonoBehaviour
{
    
    public Rigidbody rigidbody;
    public int jumpForce = 500;
    public float speed =10;
    private int count;
    public Text countText;
    public Text winText;

    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        
    }
        
    void Update() {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce (movement * speed);

        if(Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce(Vector3.up*jumpForce);
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive (false);
            count = count+1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You win!";
        }
    }
}

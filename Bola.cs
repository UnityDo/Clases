using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    float x,y;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //take inputs
         x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

    }
    void FixedUpdate()
    {
        //movement
        Vector3 movement = new Vector3(x, 0.0f, y);
        rb.AddForce(movement * speed*Time.fixedDeltaTime);
    }
}

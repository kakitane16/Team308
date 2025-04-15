using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float MoveX;
    private bool isShot;
    Rigidbody rb;
    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MoveX = -15.0f;
        isShot = false;
        velocity = new Vector3(MoveX, 10.0f, 0.0f);
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Wall")
        {
            Vector3 velocityNext = Vector3.Reflect(velocity, other.contacts[0].normal);
            velocity = velocityNext;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isShot)
        {
            rb.velocity = velocity;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           isShot = true;
        }
    }
}
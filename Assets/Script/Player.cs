using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float MoveX;
    private bool isShot;
    float distance = 0;
    Rigidbody rb;
    public Vector3 movement;
    public Vector3 MousePos;
    public Vector3 velocity;
    Plane plane = new Plane();

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
        //var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //ÉvÉåÉCÉÑÅ[ÇÃçÇÇ≥Ç…
        //plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        //if (plane.Raycast(ray, out distance))
        //{
        //    var lookPoint = ray.GetPoint(distance);
        //}
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Wall")
        {
            Vector3 velocityNext = Vector3.Reflect(velocity, other.contacts[0].normal);
            rb.velocity = velocityNext;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isShot)
        {
            rb.velocity = velocity;
            isShot=false;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           isShot = true;
        }
    }
}
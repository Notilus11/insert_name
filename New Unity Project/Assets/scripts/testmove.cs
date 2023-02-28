using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmove : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 move;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravity = -9.81f;
    private float jumpVelocity = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = controller.isGrounded;
        if (grounded && jumpVelocity < 0)
        {
            jumpVelocity = 0;
        }
        
        //translation
        move = new Vector3(x: 0, y: 0, z: Input.GetAxis("Vertical")) * speed;
        move = transform.TransformDirection(move);
        controller.Move(motion: move * Time.deltaTime);
        
        //rotation
        transform.Rotate(eulers:Time.deltaTime * rotationSpeed * new Vector3(x:0, y:Input.GetAxis("Horizontal"), z:0));
        
        //saut
        if (grounded && Input.GetKey(name: "space"))
        {
            jumpVelocity += Mathf.Sqrt(f: jumpHeight * -3.0F * gravity);
        }
        jumpVelocity += gravity * Time.deltaTime;
        controller.Move(motion: new Vector3(x: 0, y: jumpVelocity, z: 0) * Time.deltaTime);
    }
}

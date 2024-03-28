using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float boostSpeed;
    [SerializeField] float normalSpeed;
    [SerializeField] float torqueAmount;
    Rigidbody2D rgb;
    SurfaceEffector2D surfaceEffector;

    bool canMove = true;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        surfaceEffector = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            Boost();
        }

    }

    void Boost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector.speed = boostSpeed;
        }

        else
        {
            surfaceEffector.speed = normalSpeed;
        }
    }

    public void DisableControl()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rgb.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rgb.AddTorque(-torqueAmount);
        }
    }
}

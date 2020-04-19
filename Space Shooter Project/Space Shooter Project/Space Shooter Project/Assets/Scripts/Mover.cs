using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-5)]
public class Mover : MonoBehaviour
{
    private static float speed = -5.0f;

    private Rigidbody rb;

    Vector3 InitForward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InitForward = transform.forward;
        rb.velocity = transform.forward * speed;
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            speed = -15.0f;
            rb.velocity = InitForward * speed;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            speed = -5.0f;
            rb.velocity = InitForward * speed;

        }
    }
}

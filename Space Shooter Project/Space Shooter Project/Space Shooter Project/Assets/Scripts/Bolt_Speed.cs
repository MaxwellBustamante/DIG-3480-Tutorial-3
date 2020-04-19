using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt_Speed : MonoBehaviour
{
    public float bolt_speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bolt_speed;
    }
}

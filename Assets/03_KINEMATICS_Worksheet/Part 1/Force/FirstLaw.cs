using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        // rb.AddForce(Vector3.up * 100f);
        rb.AddForce(Vector3.right * 100f,ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}


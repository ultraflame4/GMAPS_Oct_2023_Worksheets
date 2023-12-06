using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToHeight : MonoBehaviour
{
    public float Height = 1f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Jump()
    {
        // v*v = u*u + 2as
        // u*u = v*v - 2as
        // u = sqrt(v*v - 2as)
        // v = 0, u = ?, a = Physics.gravity, s = Height
        
        // u is resulting velocity
        float u = Mathf.Sqrt(
            // velocity squared
            rb.velocity.y*rb.velocity.y +
            // 2 * acceleration * displacement
            2 * 10 * Height
            );
        // set the y velocity to the resulting velocity
        rb.velocity = new Vector3(rb.velocity.x,u);

        // float jumpForce = Mathf.Sqrt(-2 * Physics2D.gravity.y * Height);
        // rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}


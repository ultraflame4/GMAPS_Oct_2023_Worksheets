using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private Vector3 gravityDir, gravityNorm;
    private Vector3 moveDir;
    private Rigidbody2D rb;

    void Start() { rb = GetComponent<Rigidbody2D>(); }

    void FixedUpdate()
    {
        gravityDir = (planet.position - transform.position);
        gravityNorm = gravityDir.normalized;
        
        moveDir = new Vector3(-gravityNorm.y, gravityNorm.x, 0).normalized;
        rb.AddForce(moveDir * force * Input.GetAxisRaw("Vertical"));
        rb.AddForce(gravityDir * gravityStrength);

        float angle = Vector3.SignedAngle(Vector3.down, gravityNorm, Vector3.forward);
        rb.MoveRotation(Quaternion.Euler(0,0,angle));
        
        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
        
    }
}
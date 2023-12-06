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
        // Direction of gravity which will be vector from player to the planet
        gravityDir = (planet.position - transform.position);
        // Normalised direction of gravity
        gravityNorm = gravityDir.normalized;
        
        // Perpendicular direction to gravity will be the direction of movement
        moveDir = new Vector3(-gravityNorm.y, gravityNorm.x, 0).normalized;
        // Move in the direction of movement with the force and if the player is pressing the up/down w/s keys
        rb.AddForce(moveDir * force * Input.GetAxisRaw("Vertical"));
        // Apply gravity to attract player towards the planet
        rb.AddForce(gravityDir * gravityStrength);

        // Get angle of gravity relative to the y axis. Using vector3.down because it was rotating the other way
        float angle = Vector3.SignedAngle(Vector3.down, gravityNorm, Vector3.forward);
        // Rotate the player so they stay upright
        rb.MoveRotation(Quaternion.Euler(0,0,angle));
        
        // Draw vectors
        DebugExtension.DebugArrow(transform.position, gravityDir, Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir, Color.blue);
        
    }
}
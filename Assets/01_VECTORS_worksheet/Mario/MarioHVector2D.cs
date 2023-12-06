using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioHVector2D : MonoBehaviour
{
    public Transform planet;
    public float force = 5f;
    public float gravityStrength = 5f;

    private HVector2D gravityDir = new HVector2D();
    private HVector2D gravityNorm = new HVector2D();
    private HVector2D moveDir = new HVector2D();
    private Rigidbody2D rb;

    void Start() { rb = GetComponent<Rigidbody2D>(); }

    void FixedUpdate()
    {
        // Same as Mario.cs, but using HVector2D
        gravityDir = new HVector2D(planet.position) - new HVector2D(transform.position);
        // Copy values from gravityDir to gravityNorm
        gravityDir.CopyTo(gravityNorm);
        // Normalise gravityNorm to get normalised gravity direction
        gravityNorm.Normalize();

        // Find the direction perpendicular to gravityNorm.
        moveDir.x = -gravityNorm.y;
        moveDir.y = gravityNorm.x;
        moveDir.Normalize(); // normalise again to get a direction

        // Apply forces same as Mario.cs but using HVector2D (and converted to unity vectors)
        rb.AddForce((moveDir * force * Input.GetAxisRaw("Vertical")).ToUnityVector3());
        rb.AddForce((gravityNorm * gravityStrength).ToUnityVector3());

        // define the down vector
        HVector2D down = new HVector2D(0, -1);
        // find the angle between gravityNorm and down
        float angle = gravityNorm.FindAngle(down);
        // rotate the sprite so that it stands upright
        rb.MoveRotation(Quaternion.Euler(0, 0, Mathf.Rad2Deg*angle));

        // Draw vectors
        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);
    }
}
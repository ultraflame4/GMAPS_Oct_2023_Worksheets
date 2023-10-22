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
        gravityDir = new HVector2D(planet.position) - new HVector2D(transform.position);
        gravityDir.CopyTo(gravityNorm);
        gravityNorm.Normalize();

        moveDir.x = -gravityNorm.y;
        moveDir.y = gravityNorm.x;
        moveDir.Normalize();

        rb.AddForce((moveDir * force * Input.GetAxisRaw("Vertical")).ToUnityVector3());
        rb.AddForce((gravityDir * gravityStrength).ToUnityVector3());

        float angle = Vector3.SignedAngle(Vector3.down, gravityNorm.ToUnityVector3(), Vector3.forward);
        rb.MoveRotation(Quaternion.Euler(0, 0, angle));

        DebugExtension.DebugArrow(transform.position, gravityDir.ToUnityVector3(), Color.red);
        DebugExtension.DebugArrow(transform.position, moveDir.ToUnityVector3(), Color.blue);
    }
}
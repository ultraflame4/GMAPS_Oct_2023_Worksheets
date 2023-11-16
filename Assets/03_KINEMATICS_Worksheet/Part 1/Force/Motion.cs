using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;
        Velocity.x = 100;
        Vector3 dVel = Velocity * dt;
        transform.Translate(dVel);
    }
}

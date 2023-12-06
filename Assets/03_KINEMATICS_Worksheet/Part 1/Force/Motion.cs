using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    public Vector3 Velocity;

    void FixedUpdate()
    {
        float dt = Time.deltaTime;
        // Just multiply the vector3 by delta time no need to split it up in to dx, dy, dz when we are going to put it back together again
        Vector3 dVel = Velocity * dt;
        transform.Translate(dVel);
    }
}

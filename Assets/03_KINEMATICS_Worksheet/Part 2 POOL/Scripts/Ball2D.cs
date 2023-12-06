using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2D : MonoBehaviour
{
    public HVector2D Position = new HVector2D(0, 0);
    public HVector2D Velocity = new HVector2D(0, 0);
    
    [HideInInspector]
    public float Radius;

    private void Start()
    {
        Position.x = transform.position.x;
        Position.y = transform.position.y;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Vector2 sprite_size = sprite.rect.size;
        Vector2 local_sprite_size = sprite_size / sprite.pixelsPerUnit;
        Radius = local_sprite_size.x / 2f;
    }

    public bool IsCollidingWith(float x, float y)
    {
        // If distance between the ball center the point is less than the radius,
        // then the ball is colliding with the point
        float distance = Util.FindDistance(Position, new HVector2D(x,y));
        return distance <= Radius;
    }

    public bool IsCollidingWith(Ball2D other)
    {
        // If distance between the ball center the point is less than the combined radius,
        // ball is colliding with the other ball
        float distance = Util.FindDistance(Position, other.Position);
        return distance <= Radius + other.Radius;
    }

    public void FixedUpdate()
    {
        UpdateBall2DPhysics(Time.deltaTime);
    }

    private void UpdateBall2DPhysics(float deltaTime)
    {
        // Calculate the displacement overtime (for this frame)
        float displacementX = Velocity.x * deltaTime;
        float displacementY = Velocity.y * deltaTime;

        // Add the displacement to the position
        Position.x += displacementX;
        Position.y += displacementY;
        
        // Update the transform position of the ball
        transform.position = new Vector2(Position.x,Position.y);
    }
}


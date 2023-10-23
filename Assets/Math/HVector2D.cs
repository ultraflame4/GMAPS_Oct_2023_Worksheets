using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class        HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    // Overload the + operator to support vector addition
    public static HVector2D operator +(HVector2D a, HVector2D b)
    {
        // Return new vector with the sum of the two vectors
        return new HVector2D(a.x + b.x, a.y + b.y);
    }

    // Like the + operator, but for subtraction
    public static HVector2D operator -(HVector2D a, HVector2D b) { return new HVector2D(a.x - b.x, a.y - b.y); }

    // Vector scalar multiplication (vector * scalar) aka scaling
    public static HVector2D operator *(HVector2D a, float scalar) { return new HVector2D(a.x * scalar, a.y * scalar); }

    // Scalar division (vector / scalar) aka (vector * 1/scalar)
    public static HVector2D operator /(HVector2D a, float scalar) { return a * (1 / scalar); }

    public float Magnitude()
    {
        // Pythagoras' theorem
        // c^2 = a^2 + b^2
        // c = sqrt(a^2 + b^2)
        return Mathf.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        // To normalise a vector, we need to scale it down to a magnitude of 1
        // To do that jst divide the vector by its magnitude, because 5/5=1, 10/10=1, etc
        float m = Magnitude();
        x /= m;
        y /= m;
    }

    public float DotProduct(HVector2D b)
    {
        return (x * b.x + y * b.y);
    }

    /// <summary>
    /// Projects this vector onto vector b
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public HVector2D Projection(HVector2D b)
    {
        // Get dot product of this vector and b
        float dot_product = b.DotProduct(this);
        // Because the dot product is a*b we need to divide by b*b to "normalise" the value / get percentage / get proportion
        float total_squared = b.DotProduct(b);
        var val = (dot_product / total_squared);
        return b * val;
    }

    public float FindAngle(HVector2D other)
    {
        float d1 = DotProduct(other);
        float angle = Mathf.Acos(d1 / (Magnitude() * other.Magnitude())); // Use the other dot product formula to find the angle between the vectors
        float left = other.x * y - x * other.y; // Weird equation i found only to check if vector is left or right of the other one. Left = -1, Right = 1
        float signed = angle * Mathf.Sign(left); // Add sign to angle
        return signed;
    }

    public Vector2 ToUnityVector2()
    {
        return (Vector2)ToUnityVector3(); // change this
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, 0); // change this
    }

    public void CopyTo(HVector2D v)
    {
        v.x = x;
        v.y = y;
        v.h = h;
    }
    

    // public void Print()
    // {

    // }
}
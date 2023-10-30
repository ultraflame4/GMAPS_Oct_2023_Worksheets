using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        // your code here
    }

    public HMatrix2D(float[,] multiArray)
    {
        // your code here
    }

    public HMatrix2D(float m00, float m01, float m02,
        float m10, float m11, float m12,
        float m20, float m21, float m22)
    {
        Entries = new[,] {
                // First row
                { m00, m01, m02 },
                // Second row
                { m10, m11, m12 },
                // Third row
                { m20, m21, m22 }
        };
    }

    // public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    // {
    //     return // your code here
    // }
    //
    // public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    // {
    //     return // your code here
    // }
    //
    // public static HMatrix2D operator *(HMatrix2D left, float scalar)
    // {
    //     return // your code here
    // }
    //
    // // Note that the second argument is a HVector2D object
    // //
    // public static HVector2D operator *(HMatrix2D left, HVector2D right)
    // {
    //     return // your code here
    // }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D(
            // First row --------------------------------------------------------
            left.Entries[0, 0] * right.Entries[0, 0] +
            left.Entries[0, 1] * right.Entries[1, 0] +
            left.Entries[0, 2] * right.Entries[2, 0],
            left.Entries[0, 0] * right.Entries[0, 1] +
            left.Entries[0, 1] * right.Entries[1, 1] +
            left.Entries[0, 2] * right.Entries[2, 1],
            left.Entries[0, 0] * right.Entries[0, 2] +
            left.Entries[0, 1] * right.Entries[1, 2] +
            left.Entries[0, 2] * right.Entries[2, 2],

            // Second row --------------------------------------------------------
            left.Entries[1, 0] * right.Entries[0, 0] +
            left.Entries[1, 1] * right.Entries[1, 0] +
            left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] +
            left.Entries[1, 1] * right.Entries[1, 1] +
            left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] +
            left.Entries[1, 1] * right.Entries[1, 2] +
            left.Entries[1, 2] * right.Entries[2, 2],

            // third row row --------------------------------------------------------
            left.Entries[2, 0] * right.Entries[0, 0] +
            left.Entries[2, 1] * right.Entries[1, 0] +
            left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] +
            left.Entries[2, 1] * right.Entries[1, 1] +
            left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] +
            left.Entries[2, 1] * right.Entries[1, 2] +
            left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    // public static bool operator ==(HMatrix2D left, HMatrix2D right)
    // {
    //     // your code here
    // }
    //
    // public static bool operator !=(HMatrix2D left, HMatrix2D right)
    // {
    //     // your code here
    // }
    //
    // public override bool Equals(object obj)
    // {
    //     // your code here
    // }

    // public override int GetHashCode()
    // {
    //     // your code here
    // }
    //
    // public HMatrix2D transpose()
    // {
    //     return // your code here
    // }
    //
    // public float getDeterminant()
    // {
    //     return // your code here
    // }

    public void SetIdentity()
    {
        Entries = new[,] {
                { 1f, 0f, 0f },
                { 0f, 1f, 0f },
                { 0f, 0f, 1f }
        };
        
    }

    public void SetTranslationMat(float transX, float transY)
    {
        // your code here
    }

    public void SetRotationMat(float rotDeg)
    {
        // your code here
    }

    public void SetScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }

            result += "\n";
        }

        Debug.Log(result);
    }
}
using System;
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
        Array.Copy(multiArray, Entries, multiArray.Length);
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

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        var copy = new HMatrix2D(left.Entries);
        for (int y = 0; y < copy.Entries.GetLength(0); y++)
        for (int x = 0; x < copy.Entries.GetLength(1); x++)
            copy.Entries[y, x] += right.Entries[y, x];
        return copy;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        var copy = new HMatrix2D(left.Entries);
        for (int y = 0; y < copy.Entries.GetLength(0); y++)
        for (int x = 0; x < copy.Entries.GetLength(1); x++)
            copy.Entries[y, x] -= right.Entries[y, x];
        return copy;
    }

    //
    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        var copy = new HMatrix2D(left.Entries);
        for (int y = 0; y < copy.Entries.GetLength(0); y++)
        for (int x = 0; x < copy.Entries.GetLength(1); x++)
            copy.Entries[y, x] *= scalar;


        return copy;
    }

    // // Note that the second argument is a HVector2D object
    // //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D(
            left.Entries[0, 0] * right.x +
            left.Entries[0, 1] * right.y,
            left.Entries[1, 0] * right.x +
            left.Entries[1, 1] * right.y);
    }

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

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {

        for (int y = 0; y < left.Entries.GetLength(0); y++)
        for (int x = 0; x < left.Entries.GetLength(1); x++)
            // If there is one entry that isn't the same immediate return false (no need to continue checking)
            if (left.Entries[y, x] != right.Entries[y, x])
                return false;

        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        return !(left == right); // Simply invert the == operation
    }
    
    public override bool Equals(object obj)
    {
        if (obj.GetType() == typeof(HMatrix2D)) return (HMatrix2D)obj == this;
        return false;
    }

    // public override int GetHashCode()
    // {
    //     return Entries.GetHashCode();
    // }
    // //
    public HMatrix2D transpose()
    {
        return new HMatrix2D(
            Entries[0, 0], Entries[1, 0], Entries[2, 0],
            Entries[0, 1], Entries[1, 1], Entries[2, 1],
            Entries[0, 2], Entries[1, 2], Entries[2, 2]
        );
    }
    //
    // public float getDeterminant()
    // {
    //     return // your code here
    // }

    public void SetIdentity()
    {
        for (int y = 0; y < Entries.GetLength(0); y++)
        for (int x = 0; x < Entries.GetLength(1); x++)
            Entries[y, x] = (y == x) ? 1 : 0;
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
using System;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    private void Start()
    {
        mat.SetIdentity();
        mat.Print();
        
        Question2();
    }

    void Question2()
    {
        var matA = new HMatrix2D(
            1f, 2f, 1f,
            0f, 1f, 0f,
            2f, 3f, 4f
        );
        var matB = new HMatrix2D(
            2f, 5f, 1f,
            6f, 7f, 1f,
            1f, 8f, 1f
        );

        (matA * matB).Print();
        
    }
}
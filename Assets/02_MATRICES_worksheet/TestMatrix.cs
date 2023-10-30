using System;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    private void Start()
    {
        mat.SetIdentity();
        mat.Print();
    }
}
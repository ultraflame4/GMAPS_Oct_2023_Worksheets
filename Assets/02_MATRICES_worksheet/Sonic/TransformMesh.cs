// Uncomment this whole file.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    private float rotate_angle = 0f;
    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);
        
        Translate(3,3);
        Rotate( rotate_angle * Mathf.Deg2Rad);
        // Your code here
    }

    
    void Translate(float x, float y)
    {
        transformMatrix.SetIdentity();
        transformMatrix.SetTranslationMat(x, y);
        Transform();
        pos = transformMatrix * pos;
    }

    void Rotate(float angle)
    {
        toOriginMatrix.SetIdentity();
        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.SetIdentity();
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y);
        
        rotateMatrix = new HMatrix2D();
        rotateMatrix.SetRotationMat(angle);
        
        transformMatrix.SetIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;
    
        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
            // Debug.Log(vertices[i]);
        }

        meshManager.clonedMesh.vertices = vertices;
    }

    private void Update()
    {
        rotate_angle+= 0.01f * Time.deltaTime;
        if (rotate_angle > 360) rotate_angle = 0;
        Rotate( rotate_angle * Mathf.Deg2Rad);
    }
}
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
        // don't really need to set identity because set translation mat will overwrite (and set the identity) anyways
        toOriginMatrix.SetIdentity(); 
        // vector to origin is basically negative of position (because the position is the vector from origin to the object)
        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y);
        fromOriginMatrix.SetIdentity();
        // vector from origin is the position
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y);
        
        // Create a rotation matrix
        rotateMatrix = new HMatrix2D();
        rotateMatrix.SetRotationMat(angle);
        
        // Combine the matrices
        transformMatrix.SetIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix;
    
        Transform();
    }

    private void Transform()
    {
        // Copy the vertices array from the original mesh
        vertices = meshManager.clonedMesh.vertices;

        // Transform each vertex
        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = transformMatrix * vert;
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
            // Debug.Log(vertices[i]);
        }

        // Copy the transformed vertices back to the mesh
        meshManager.clonedMesh.vertices = vertices;
    }

    private void Update()
    {
        // Rotate the mesh overtime
        rotate_angle+= 0.01f * Time.deltaTime;
        // If the angle is greater than 360, reset it to 0
        if (rotate_angle > 360) rotate_angle = 0;
        // Rotate the mesh using the angle.
        Rotate( rotate_angle * Mathf.Deg2Rad);
    }
}
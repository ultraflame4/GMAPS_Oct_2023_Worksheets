using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    public bool IsCaptain = false;
    public SoccerPlayer[] OtherPlayers;
    public float rotationSpeed = 1f;

    float angle = 0f;

    private void Start()
    {
        OtherPlayers = FindObjectsOfType<SoccerPlayer>().Where(x => x != this).ToArray();
        
        if (IsCaptain) FindClosestPlayerDot();
    }

    float Magnitude(Vector3 vector) => Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);

    Vector3 Normalise(Vector3 vector) => vector / Magnitude(vector);

    float Dot(Vector3 vectorA, Vector3 vectorB) => vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z;

    SoccerPlayer FindClosestPlayerDot()
    {
        SoccerPlayer closest = null;
        float minAngle = 180f;
        foreach (SoccerPlayer player in OtherPlayers)
        {
            Vector3 toPlayer = Normalise(player.transform.position - transform.position);
            float dot = Dot(transform.forward, toPlayer);
            float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
            if (closest == null || angle < minAngle)
            {
                minAngle = angle;
                closest = player;
            }
        }
        
        return closest;
    }

    void DrawVectors()
    {
        foreach (SoccerPlayer other in OtherPlayers)
        {
            Vector3 toPlayer = other.transform.position - transform.position;
            Debug.DrawRay(transform.position, toPlayer, Color.black);   
        }
    }

    void Update()
    {
        
        
        DebugExtension.DebugArrow( transform.position, transform.forward, Color.red);
        if (IsCaptain)
        {
            angle += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Debug.DrawRay(transform.position,transform.forward * 10,Color.red);
            
            DrawVectors();
            
            SoccerPlayer target = FindClosestPlayerDot();
            target.GetComponent<Renderer>().material.color = Color.green;
            foreach (SoccerPlayer other in OtherPlayers.Where(x => x != target))
            {
                other.GetComponent<Renderer>().material.color = Color.white;
            }
            
        }
    }
}



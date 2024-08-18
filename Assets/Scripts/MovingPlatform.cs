using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    private Vector3 target;

    void Start()
    {
        target = pointA;
    }

    
    void Update()
    {
       // Move the platform towards the target
       transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

       // If the platform reaches the target point, switch targets
       if (Vector3.Distance(transform.position, target) < 0.1f)
       {
            target = target == pointA ? pointB : pointA;
       }
    }

    void OnDrawGizmos()
    {
        // Draw a line in the editor to visulize path
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pointA, pointB);
    }
}

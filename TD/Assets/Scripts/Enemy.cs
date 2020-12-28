using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int WavePointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    
    if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

    void GetNextWaypoint()
        {
            if (WavePointIndex >= Waypoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            WavePointIndex++;
            target = Waypoints.points[WavePointIndex];
        }
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFollower : MonoBehaviour
{
    [SerializeField] Transform[] Waypoints;
    int WaypointIndex = 0;
    public float speed;
    void Update()
    {
        if (WaypointIndex < Waypoints.Length-1)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Waypoints[WaypointIndex].transform.position, speed * Time.deltaTime);

            if (transform.position == Waypoints[WaypointIndex].transform.position)
            {
                WaypointIndex += 1;
            }
            if (WaypointIndex == Waypoints.Length)
            {
                speed = 0;
            }
            Vector3 characterScale = transform.localScale;
            if (transform.position.x > Waypoints[WaypointIndex].transform.position.x)
            {
                characterScale.x = -1;
            }
            else if (transform.position.x < Waypoints[WaypointIndex].transform.position.x)
            {
                characterScale.x = 1;
            }
            transform.localScale = characterScale;
        }
    }
}

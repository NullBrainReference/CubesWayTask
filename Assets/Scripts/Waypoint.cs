using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WaypointFollower follower = other.GetComponent<WaypointFollower>();
            follower.NextPoint();
        }
    }
    public Vector3 GetPosXZ(float y)
    {
        Vector3 pos = new Vector3(
            transform.position.x,
            y,
            transform.position.z
            );

        return pos;
    }
}

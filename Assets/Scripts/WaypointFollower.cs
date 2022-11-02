using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints;

    private int waypointIndex = 0;
    private float dX = 0;

    [SerializeField] private float speed;

    [SerializeField] private GameObject waypointPrefab;
    [SerializeField] private Rigidbody rb;

    public float DeltaX { get { return dX; } }

    private void Start()
    {
        waypoints = new List<Waypoint> { };
    }

    private void FixedUpdate()
    {
        if (GameStageController.Instance.Stage == GameStageController.GameStage.Planning)
            return;

        Move();
    }

    private void Move()
    {
        if (GameStageController.Instance.Stage == GameStageController.GameStage.Planning)
            return;

        if (waypointIndex >= waypoints.Count) return;

        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    waypoints[waypointIndex].GetPosXZ(transform.position.y),
        //    speed * Time.deltaTime);

        Vector3 dir =
            waypoints[waypointIndex].GetPosXZ(rb.velocity.y) -
            transform.position;
        dir.Normalize();

        if(rb.velocity.magnitude < 1)
            rb.AddForce(dir*speed);
        //rb.velocity = dir * speed * Time.deltaTime;

        dX += speed * Time.deltaTime;
    }

    public void NextPoint()
    {
        waypointIndex++;
    }

    public void AddWaypoint(Vector3 position)
    {
        PlayerManager.actions.Add(() =>
        {
            GameObject newObject = Instantiate(waypointPrefab, position, new Quaternion());
            Waypoint waypoint = newObject.GetComponent<Waypoint>();
            waypoints.Add(waypoint);
        });
    }

    public void RemoveLastWaypoint()
    {
        waypoints.RemoveAt(waypoints.Count - 1);
    }
}

using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] waypoints; //Array voor de waypoints
    public float speed = 2f;
    private int currentWaypointIndex = 0;

    void Update()
    {
        //beweegt naar volgende waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        //kijkt of de enemy bij de volgende waypoint is aangekomen
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length; //looped de waypoints
        }
    }
}
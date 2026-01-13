using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    private int currentPointIndex = 0;

    void Update()
    {
        if (currentPointIndex < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                waypoints[currentPointIndex].position,
                speed * Time.deltaTime
            );

            if(Vector3.Distance(transform.position, waypoints[currentPointIndex].position) < 0.1f)
            {
                currentPointIndex++;
            }
        }
        else
        {
            currentPointIndex = 0;
        }
    }
}

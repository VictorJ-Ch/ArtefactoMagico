using UnityEngine;

public class StaffageBehaviour : MonoBehaviour
{
    public Transform[] wayPoints;
    public float staffageSpeed = 5f;
    public float staffageRotSpeed = 5f;
    private int currentWayPointIndex = 0;
    private Quaternion originalRotation;


    void Start()
    {
        originalRotation = new Quaternion(-2.01910711e-06f, -0.707106829f, -0.707106829f, 2.01910711e-06f); // Setea la rotación inicial
        transform.rotation = originalRotation;
    }

    void Update()
    {
        if (wayPoints.Length == 0) return;

        Vector3 staffageDirection = wayPoints[currentWayPointIndex].position - transform.position;
        staffageDirection.y = 0;

        if (staffageDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(staffageDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, staffageRotSpeed * Time.deltaTime);

            transform.rotation = new Quaternion(originalRotation.x, transform.rotation.y, originalRotation.z, transform.rotation.w);
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPointIndex].position, staffageSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, wayPoints[currentWayPointIndex].position) < 0.1f)
        {
            currentWayPointIndex++;

            if (currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }
    }
}

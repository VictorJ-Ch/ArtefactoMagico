using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    [Header("NavMesh")]
    public NavMeshAgent enemy;
    public Transform target;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    private float nextFireTime;

    [Header("Bool")]
    public bool isChasing;

    [Header("Float")]
    public float enemySpeed;
    public float range;
    public float distance;

    void Start()
    {
        enemy.updateRotation = false;
        transform.rotation = Quaternion.Euler(270f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        if (enemy == null)
        {
            Debug.LogError("Enemy not found!");
        }

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
        else
        {
            Debug.LogError("Target not assigned!");
        }
    }

    void Update()
    {
        Vector3 direction = enemy.velocity;
        direction.y = 0;
        
        if (direction.magnitude > 0.1f)
        {
            transform.forward = direction.normalized;
        }
        
        if (Mathf.Abs(transform.rotation.eulerAngles.x - 270f) > 0.1f)
        {
            transform.rotation = Quaternion.Euler(270f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        if (target != null)
        {
            distance = Vector3.Distance(enemy.transform.position, target.position);
        }
        else
        {
            Debug.LogError("Target es nulo!");
            return;
        }
            

        if (distance < range)
        {
            isChasing = true;
            ShootAtPlayer();
        }
        else
        {
            isChasing = false;
        }

        //Chasing
        if (!isChasing)
        {
            enemy.speed = 0f;
        }
        else
        {
            enemy.speed = enemySpeed;
            enemy.destination = target.position;
        }
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(270f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }



    void ShootAtPlayer()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * 5f, Color.blue);

        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            bullet.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            bullet.transform.rotation = Quaternion.LookRotation(firePoint.forward);


            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = firePoint.forward * 10f;
            }
            else
            {
                Debug.LogWarning("La bala no tiene Rigidbody!");
            }
            Destroy(bullet, 5f);
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.transform.position, range);
    }
}

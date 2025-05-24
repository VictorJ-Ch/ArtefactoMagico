using UnityEngine;
using UnityEngine.AI;

public class MonsterWhiteBehaviour : MonoBehaviour
{
    [Header("NavMesh")]
    public NavMeshAgent enemy;
    public Transform target;

    [Header("Spawning")]
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnRate = 2f;
    private float nextSpawnTime;

    [Header("Bool")]
    public bool isChasing;

    [Header("Float")]
    public float enemySpeed;
    public float range;
    public float distance;

    [Header("Orb")]
    public GameObject orbPrefab;

    void Start()
    {
        enemy.updateRotation = false;
        transform.rotation = Quaternion.Euler(270f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        if (enemy == null)
        {
            Debug.LogError("Enemy not found!");
        }

        if (target == null)
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

        distance = Vector3.Distance(enemy.transform.position, target.position);

        if (distance < range)
        {
            isChasing = true;
            SpawnEnemy();
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
            enemy.destination = target.transform.position;
        }
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(270f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    void SpawnEnemy()
    {
        Debug.DrawRay(spawnPoint.position, spawnPoint.forward * 5f, Color.green);

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + 1f / spawnRate;
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            newEnemy.transform.localScale = new Vector3(50f, 50f, 50f);
            newEnemy.transform.rotation = Quaternion.LookRotation(spawnPoint.forward);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(enemy.transform.position, range);
    }
    
    void OnDisable()
    {
        if (orbPrefab != null)
        {
            Instantiate(orbPrefab, transform.position, Quaternion.identity);
        }
    }
}

using UnityEngine;

public class StaffageSpawner : MonoBehaviour
{
    [Header("Objects")]
    public GameObject cucarachaPrefab;
    public Transform spawnPoint;
    public Transform wayPointsParent;
    [Header("Variables")]
    public int maxCucarachas = 15;
    public float spawnInterval = 5f;
    private int cucarachaCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnCucaracha), spawnInterval, spawnInterval);
    }

    void SpawnCucaracha()
    {
        if (cucarachaCount >= maxCucarachas)
        {
            CancelInvoke(nameof(SpawnCucaracha));
            return;
        }

        GameObject newCucaracha = Instantiate(cucarachaPrefab, spawnPoint.position, spawnPoint.rotation);
        
        StaffageBehaviour cucarachaScript = newCucaracha.GetComponent<StaffageBehaviour>();
        if (cucarachaScript != null)
        {
            cucarachaScript.wayPoints = wayPointsParent.GetComponentsInChildren<Transform>();
        }

        cucarachaCount++;
    }
}

using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float projectileSpeed = 50.0f;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }
}

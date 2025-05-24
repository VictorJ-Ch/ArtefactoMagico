using UnityEngine;

public class DeathScript : MonoBehaviour
{
    public bool isBoss;
    private int hitCount = 0;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            hitCount++;
            Debug.Log(gameObject.name + " fue golpeado por un proyectil. Golpes recibidos: " + hitCount);

            if (isBoss && hitCount >= 10)
            {
                Destroy(gameObject);
                Debug.Log(gameObject.name + " ha sido destruido.");
            }
            else
            {
                Invoke("DisableEnemy", 0.1f);
            }
        }
    }

    void DisableEnemy()
    {
        if (gameObject != null)
        {
            gameObject.SetActive(false);
            Debug.Log(gameObject.name + " ha sido desactivado.");
        }
    }
}

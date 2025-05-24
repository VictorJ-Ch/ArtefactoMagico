using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    private UIManager uiManager;
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        uiManager = FindObjectOfType<UIManager>();

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            currentHealth--;
            Debug.Log("Vida del jugador: " + currentHealth);

            UpdateHealthUI();

            if (currentHealth <= 0)
            {
                uiManager.UpdateWinOrLoose(false, true);
                Debug.Log("El jugador ha perdido.");
            }
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
}

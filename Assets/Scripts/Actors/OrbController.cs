using UnityEngine;

public class OrbController : MonoBehaviour
{
    public float detectionRange = 5f;
    public KeyCode interactKey = KeyCode.E;
    public bool isPlayerInRange = false;

    private GameObject player;
    private UIManager uiManager;

    void Awake()
    {
        gameObject.SetActive(true);
    }

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            isPlayerInRange = distance <= detectionRange;

            if (isPlayerInRange)
            {
                Debug.Log("Interactuar con Orbe (E)");
                uiManager.UpdatePanelState(true);

                if (Input.GetKeyDown(interactKey))
                {
                    ActivateWinPanel();
                }
            }
            else
            { 
                uiManager.UpdatePanelState(false);
            }
        }
    }

    private void ActivateWinPanel()
    {
        Debug.Log("¡Has ganado!");
        gameObject.SetActive(false);
        uiManager.UpdateWinOrLoose(true, false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

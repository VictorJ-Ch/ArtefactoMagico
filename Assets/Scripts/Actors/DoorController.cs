using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject player;
    public float detectionRange = 3f;
    public KeyCode interactKey = KeyCode.E;
    private bool isPlayerInRange = false;
    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            isPlayerInRange = distance <= detectionRange;

            if (isPlayerInRange && player.GetComponent<PlayerInventory>().hasKey)
            {
                uiManager.UpdatePanelState(true);

                if (Input.GetKeyDown(interactKey))
                {
                    OpenDoor();
                }
            }
            else
            {
                uiManager.UpdatePanelState(false);
            }
        }
    }

    private void OpenDoor()
    {
        Debug.Log("La cripta se ha abierto");
        gameObject.SetActive(false);
        uiManager.UpdatePanelState(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, detectionRange);
    }
}

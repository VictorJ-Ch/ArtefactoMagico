using UnityEngine;
using UnityEngine.InputSystem;

public class KeyController : MonoBehaviour
{
    public GameObject player;
    public float detectionRange = 5f;
    public KeyCode interactKey = KeyCode.E;
    public bool isPlayerInRange = false;

    private UIManager uiManager;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (player != null)
        {
            float distance  = Vector3.Distance(transform.position, player.transform.position);

            if(distance <= detectionRange)
            {
                isPlayerInRange = true;
                Debug.Log("Recoger llave E");
                uiManager.UpdatePanelState(true);
            }
            else
            {
                isPlayerInRange = false;
                uiManager.UpdatePanelState(false);
            }



            if(isPlayerInRange && Input.GetKeyDown(interactKey))
            {
                PerformAction();
            }
        }
    }


    private void PerformAction()
    {
        Debug.Log("Tenes la llave de la cripta");
        player.GetComponent<PlayerInventory>().hasKey = true;
        gameObject.SetActive(false);
        uiManager.UpdatePanelState(false);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, detectionRange);
    }
}

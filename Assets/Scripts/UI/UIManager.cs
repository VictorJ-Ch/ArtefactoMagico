using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject interactiveKey;
    public bool isActive = false;


    public GameObject winPanel;
    public bool playerWin = false;

    
    public GameObject loosePanel;
    public bool playerLoose = false;


    public void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        if (loosePanel != null)
        {
            loosePanel.SetActive(false);
        }

        if (interactiveKey != null)
        {
            interactiveKey.SetActive(false);
        }
    }

    public void UpdatePanelState(bool newState)
    {
        isActive = newState;

        if (interactiveKey != null)
        {
            interactiveKey.SetActive(newState);

        }
    }


    public void UpdateWinOrLoose(bool winState, bool looseState)
    {
        playerWin = winState;
        playerLoose = looseState;

        if (winPanel != null)
        {
            winPanel.SetActive(winState);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }

        if (loosePanel != null)
        {
            loosePanel.SetActive(looseState);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
    }
}

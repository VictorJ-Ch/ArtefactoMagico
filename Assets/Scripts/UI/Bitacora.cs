using UnityEngine;

public class Bitacora : MonoBehaviour
{
    public GameObject bitacora;
    private bool isActive = false;

    void Start()
    {
        bitacora.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isActive = !isActive;
            if (isActive)
            {
                bitacora.SetActive(true);
            }
            else
            {
                bitacora.SetActive(false);
            }
        }
    }
}

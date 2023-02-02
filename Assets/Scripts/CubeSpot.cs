using UnityEngine;

public class CubeSpot : MonoBehaviour, IGrabbable
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject endGameMenu;
    private IGrabbable grabbable;

    private void Awake()
    {
        endGameMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("interCube"))
        {
            other.transform.SetPositionAndRotation(transform.position, transform.rotation);
        } 
        if (!other.TryGetComponent<InteractWithObject>(out var interactWithObject)) return;

        interactWithObject.FinishGame();
        Release();
        Invoke(nameof(Win), 2);
    }

    private void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endGameMenu.SetActive(true);
    }

    
    public void Release(){
           
    }
}

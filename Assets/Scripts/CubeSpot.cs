using UnityEngine;

public class CubeSpot : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject endGameMenu;

    private void Awake()
    {
        endGameMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("interCube")) return; 
        if (!other.TryGetComponent<InteractWithCube>(out var interactWithCube)) return;

        interactWithCube.FinishGame();
        interactWithCube.Release();
        interactWithCube.transform.SetPositionAndRotation(transform.position, transform.rotation);

        Invoke(nameof(Win), 2);
    }

    private void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endGameMenu.SetActive(true);
    }
}

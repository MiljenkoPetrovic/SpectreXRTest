using TMPro;
using UnityEngine;

public class CubeSpot : MonoBehaviour, IGrabbable
{
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject endGameMenu;
    [SerializeField] private GameObject cubePlaceholder;
    private IGrabbable grabbable;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Awake()
    {
        endGameMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        initialPosition = cubePlaceholder.transform.position;
        initialRotation = cubePlaceholder.transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("interCube")) return;
        if (!other.TryGetComponent<InteractWithCube>(out var interactWithCube)) return;
        Snap(initialPosition, initialRotation, other.transform);
        interactWithCube.FinishGame();
        Invoke(nameof(Win), 2);
    }

    private void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endGameMenu.SetActive(true);
    }

    public void Grab() { }
    public void Release(){ }

    private void Snap(Vector3 initialPosition, Quaternion initialRotation, Transform _transform)
    {
        _transform.SetPositionAndRotation(initialPosition, initialRotation);
    }
}

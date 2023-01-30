using UnityEngine;


public class InteractWithCube : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Transform _transform;
    private bool isGrabbed;

    public bool IsGrabbed => isGrabbed;
    private bool isGameFinished;

    private void Start()
    {
        _transform = transform;
        initialPosition = _transform.position;
    }

    public void Grab()
    {
        SetParent(player);
        isGrabbed = true;
    }

    public void Release()
    {
        SetParent(null);
        isGrabbed = false;

        if (!isGameFinished)
        {
            _transform.SetPositionAndRotation(initialPosition, initialRotation);
        }
    }

    public void SetParent(Transform parent)
    {
        _transform.SetParent(parent);
    }

    public void FinishGame()
    {
        isGameFinished = true;
    }
}

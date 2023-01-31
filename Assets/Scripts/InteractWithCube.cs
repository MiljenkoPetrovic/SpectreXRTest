using UnityEngine;


public class InteractWithCube : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Transform _transform;
    private float distance;

    private bool isGrabbed;
    public bool IsGrabbed => isGrabbed;
    private bool isGameFinished;

    private void Start()
    {
        _transform = transform;
        initialPosition = _transform.position;
        initialRotation = _transform.rotation;
    }

    private void Update()
    {
        if (isGrabbed)
        {
            var direction = player.transform.forward;
            _transform.SetPositionAndRotation((player.position + direction * distance), (player.rotation));
        }
        else
        {
            if (!isGameFinished)
            {
                _transform.SetPositionAndRotation(initialPosition, initialRotation);
            }
        }
    }

    public void Grab()
    {
        isGrabbed = true;
        distance = Vector3.Distance(player.position, _transform.position);
    }

    public void Release()
    {
        isGrabbed = false;

        if (!isGameFinished)
        {
            _transform.SetPositionAndRotation(initialPosition, initialRotation);
        }
    }

    public void FinishGame()
    {
        isGameFinished = true;
    }
}

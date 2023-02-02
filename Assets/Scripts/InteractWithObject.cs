using UnityEngine;

public class InteractWithObject : MonoBehaviour, IGrabbable
{
    [SerializeField] private Transform player;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Transform _transform;
    private float distance;

    private bool isGrabbed;
    private bool isTheCubeCorrect;

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
            if (!isGrabbed)
            {
                if(!isTheCubeCorrect)
                {
                _transform.SetPositionAndRotation(initialPosition, initialRotation);
                }
            }
        }
    }

    public void FinishGame()
    {
        isTheCubeCorrect = true;
    }
}

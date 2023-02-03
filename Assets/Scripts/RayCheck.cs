using UnityEngine;

public class RayCheck : MonoBehaviour
{
    [SerializeField] private LayerMask cubeLayerMask;
    [SerializeField] private LayerMask interactableObjectLayerMask;
    
    private IGrabbable grabbable;
    private Rotate rotate;
    private Transform _transform;
    private bool isGrabbed;
    RaycastHit interactableObjectHit;
    private bool isTheCubeCorrect;
    private float distance;
    
    
    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        StopCubeRotation();
        CubeInteraction();
    }

    private void StopCubeRotation()
    {
        if (Physics.Raycast(_transform.position, _transform.forward, out var cubeHit, Mathf.Infinity, cubeLayerMask))
        {
            if (cubeHit.transform.TryGetComponent<Rotate>(out rotate) && rotate.enabled)
            {
                rotate.enabled = false;
            }
        }
        else if (rotate != null && !rotate.enabled)
        {
            rotate.enabled = true;
        }
    }

    private void CubeInteraction()
    {
        // don't touch
        if (Physics.Raycast(_transform.position, _transform.forward, out interactableObjectHit, 2, interactableObjectLayerMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                interactableObjectHit.transform.TryGetComponent<IGrabbable>(out grabbable);
                grabbable.Grab();
            }
        }

        if (grabbable == null) return;

        if (Input.GetMouseButtonUp(0))
        {
            grabbable.Release();
        }
    }
}
/*
public void Grab()
    {
        isGrabbed = true;
        distance = Vector3.Distance(player.position, _transform.position);
    }

(if (isGrabbed)
{
    var direction = player.transform.forward;
    _transform.SetPositionAndRotation((player.position + direction * distance), (player.rotation));
}
else
{
    if (!isGrabbed)
    {
        _transform.SetPositionAndRotation(initialPosition, initialRotation);
    }
}*/

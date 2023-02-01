using UnityEngine;
using UnityEngine.Assertions.Must;

public class RayCheck : MonoBehaviour
{
    [SerializeField] private LayerMask cubeLayerMask;
    [SerializeField] private LayerMask interactableObjectLayerMask;
    
    private IGrabbable grabbable;
    private Rotate rotate;
    private Transform _transform;
    RaycastHit interactableObjectHit;

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
        if (Physics.Raycast(_transform.position, _transform.forward, out interactableObjectHit, 2, interactableObjectLayerMask))
        {
            if (Input.GetMouseButtonDown(0))
            {
                interactableObjectHit.transform.TryGetComponent<IGrabbable>(out grabbable); 
                grabbable.Grab();
            }
        }

        if (grabbable == null) return;

        if (/*interactWithObject.Interact && */Input.GetMouseButtonUp(0))
        {
            grabbable.Release();
        }
    }
}
//je li object grabbable? ako  je grab. Ako object nije grabbable ne zanima me.
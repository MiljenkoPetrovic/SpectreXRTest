using UnityEngine;

public class RayCheck : MonoBehaviour
{
    [SerializeField] private LayerMask cubeLayerMask;
    [SerializeField] private LayerMask interactableCubeLayerMask;
    [SerializeField] private InteractWithCube interactWithCube;

    private Rotate rotate;
    private Transform _transform;

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
        if (Physics.Raycast(_transform.position, _transform.forward, out var interactableCubeHit, 2, interactableCubeLayerMask))
        {

            if (Input.GetMouseButtonDown(0))
            {
                interactWithCube.Grab();
            }
        }

        if (interactWithCube.IsGrabbed && Input.GetMouseButtonUp(0))
        {
            interactWithCube.Release();
        }
    }
}

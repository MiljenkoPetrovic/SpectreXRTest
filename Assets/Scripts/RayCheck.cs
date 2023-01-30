using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RayCheck : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask layerMask2;
    private Rotate rotate;
    private InteractWithCube cubeInter;
    [SerializeField] InteractWithCube intCube;
    [SerializeField] new GameObject camera;

<<<<<<< Updated upstream
=======
    private void Awake()
    {
        _transform = transform;
        Cursor.lockState = CursorLockMode.Locked;
    }
>>>>>>> Stashed changes

    void Update()
    {
        //Vidim nesto
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, layerMask))
        {
            //to što vidim je kocka
            if (hit.transform.TryGetComponent<Rotate>(out rotate) && rotate.enabled)
            {
                //zaustavi se
                rotate.enabled = false;
            }
        }
        else if (rotate != null && !rotate.enabled)
        {
            rotate.enabled = true;
        }
<<<<<<< Updated upstream

        if (Physics.Raycast(transform.position, transform.forward, out var hitInteract, 2, layerMask2))
=======
    }
    
    private void CubeInteraction()
    {
        if (Physics.Raycast(_transform.position, _transform.forward, out var interactableCubeHit, 2, interactableCubeLayerMask))
>>>>>>> Stashed changes
        {
            
            if (hitInteract.transform.TryGetComponent<InteractWithCube>(out cubeInter) && Input.GetMouseButtonDown(0))
            {
                intCube.Grab();
            }

        }

        if (intCube.IsGrabbed && Input.GetMouseButtonUp(0))
        {
            intCube.Release();
        }

    }
}

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

        if (Physics.Raycast(transform.position, transform.forward, out var hitInteract, 2, layerMask2))
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

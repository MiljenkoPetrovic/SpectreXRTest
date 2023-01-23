using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCheck : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Rotate rotate;

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
    }
}

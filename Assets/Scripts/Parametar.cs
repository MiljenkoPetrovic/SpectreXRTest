using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Parametar : MonoBehaviour
{
    public new GameObject camera;
    public Bounce bounce;
    [SerializeField] private Material newMaterial;
    [SerializeField] private Material oldMaterial;

    void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("MainCamera"))
        {
            if (bounce.enabled == false)
            {
                bounce.enabled = true;
                transform.gameObject.GetComponent<MeshRenderer>().material = newMaterial;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            
            if (bounce.enabled == true)
            {
                bounce.enabled = false;
                transform.gameObject.GetComponent<MeshRenderer>().material = oldMaterial;
            }
        }
    }
}
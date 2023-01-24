using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Parametar : MonoBehaviour
{

    private Bounce bounce;
    [SerializeField] private Material newMaterial;
    [SerializeField] private Material oldMaterial;
 
    
    void Start()
    {
        
    }



    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Cube")
        {
            
            if (collider.TryGetComponent<Bounce>(out bounce) && bounce.enabled == false)
            {
                bounce.enabled = true;
                collider.GetComponent<MeshRenderer>().material = newMaterial;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            
            if (other.TryGetComponent<Bounce>(out bounce) && bounce.enabled == true)
            {
                bounce.enabled = false;
                other.GetComponent<MeshRenderer>().material = oldMaterial;
            }
        }
    }
}
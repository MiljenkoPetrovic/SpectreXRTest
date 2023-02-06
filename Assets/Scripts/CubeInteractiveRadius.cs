using UnityEngine;

public class CubeInteractiveRadius : MonoBehaviour
{
    [SerializeField] private Bounce bounce;
    [SerializeField] private Material newMaterial;
    [SerializeField] private Material oldMaterial;
    [SerializeField] private Renderer _renderer;

    private static readonly string cameraTag = "MainCamera";

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(cameraTag) || bounce.enabled) return;

        bounce.enabled = true;
        _renderer.material = newMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(cameraTag) || !bounce.enabled) return;
        
        bounce.enabled = false;
        _renderer.material = oldMaterial;
    }
}

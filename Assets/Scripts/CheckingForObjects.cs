using UnityEngine;

public abstract class CheckingForObjects : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    
    private Transform _transform;
    
    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        if (Physics.Raycast(_transform.position, _transform.forward, out var interactableObjectHit, float.MaxValue, layerMask))
        {
            ObjectFound(interactableObjectHit);
        }
        else
        {
            NotHit();
        }
    }

    protected abstract void ObjectFound(RaycastHit hit);
    protected virtual void NotHit() { }
}

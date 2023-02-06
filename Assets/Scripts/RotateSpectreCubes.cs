using UnityEngine;

public class RotateSpectreCubes : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        _transform.Rotate(Vector3.up, Time.deltaTime * 30);
    }
}
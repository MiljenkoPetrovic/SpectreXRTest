using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Vector3 initialPosition;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        initialPosition = _transform.position;
    }

    private void Update()
    {
        _transform.position = new Vector3(initialPosition.x, Mathf.Sin(Time.time) + initialPosition.y, initialPosition.z);
    }

    private void OnDisable()
    {
        _transform.position = initialPosition;
    }
}

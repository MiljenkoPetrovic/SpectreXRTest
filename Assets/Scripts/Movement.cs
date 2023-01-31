using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1;
    [SerializeField] private float runSpeed = 2;
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector2 sensitivity;

    private Vector2 rotation;
    private Vector2 keyboardInput;
    private Transform _transform;
    private Vector2 MouseInput =>  new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    void Start()
    {
        Cursor.visible = false;
        _transform = transform;
        _camera.rotation = Quaternion.identity;
    }

    private void Update()
    {
        Vector2 wantedVelocity = MouseInput * sensitivity;

        rotation += wantedVelocity * Time.deltaTime;

        rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);

        _camera.transform.rotation = Quaternion.Euler(rotation.y, rotation.x, 0);

        var speed = Input.GetKeyDown(KeyCode.LeftShift) ? walkSpeed * runSpeed : walkSpeed;

        keyboardInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        var projection = Vector3.ProjectOnPlane(_camera.forward, Vector3.up);

        var direction = GetMoveDirection(projection);

        _transform.Translate(Time.deltaTime * speed * direction);
    }

    private Vector3 GetMoveDirection(Vector3 cameraForwardProjection)
    {
        var forwardProjection = new Vector2(cameraForwardProjection.x, cameraForwardProjection.z).normalized;
        var angle = Vector2.Angle(forwardProjection, Vector2.up) * Mathf.Deg2Rad;
        angle = forwardProjection.x > 0 ? -angle : angle;
        var cos = Mathf.Cos(angle);
        var sin = Mathf.Sin(angle);
        var x = keyboardInput.x * cos - keyboardInput.y * sin;
        var y = keyboardInput.x * sin + keyboardInput.y * cos;

        return new Vector3(x, 0, y);
    }
}

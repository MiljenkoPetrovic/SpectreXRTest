using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Movement : MonoBehaviour
{
    [SerializeField] float walk = 1;
    [SerializeField] float run = 2;
    [SerializeField] Transform _camera;
    private Vector3 lastMouse = new(255, 255, 255); //Sredina ekrana
    private Vector3 direction;
    Vector2 movemement = Vector2.zero;
    private Rigidbody rb;

    public Movement(Rigidbody rb)
    {
        this.rb = rb;
    }

    public Vector2 sensitivity;
    private Vector2 rotation;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;

    }

    
    private Vector2 GetInput()
    {
            Vector2 input = new(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"));

        return input;
    }
        
    private void Update()
    {
        Vector2 wantedVelocity = GetInput() * sensitivity;
        rotation += wantedVelocity * Time.deltaTime;
        
        _camera.localEulerAngles = new Vector3(Mathf.Clamp(rotation.y, -90f, 90f), rotation.x, 0);
        

        if (Input.GetKeyDown(KeyCode.LeftShift)) walk += run;
        if (Input.GetKeyUp(KeyCode.LeftShift)) walk -= run;

        float horizontal = Input.GetAxis("Vertical");
        float vertical = Input.GetAxis("Horizontal");
        movemement = new Vector2(vertical, horizontal);
        var projection = Vector3.ProjectOnPlane(_camera.forward,Vector3.up);
        direction = GetMoveDirection(projection);
        transform.Translate(Time.deltaTime * walk * direction);
    }

    public Vector3 GetMoveDirection(Vector3 cameraForwardProjection)
    {
        var forwardProjection = new Vector2(cameraForwardProjection.x, cameraForwardProjection.z).normalized;
        var angle = Vector2.Angle(forwardProjection, Vector2.up) * Mathf.Deg2Rad;
        angle = forwardProjection.x > 0 ? -angle : angle;
        var cos = Mathf.Cos(angle);
        var sin = Mathf.Sin(angle);
        var x = movemement.x * cos - movemement.y * sin;
        var y = movemement.x * sin + movemement.y * cos;
        return new Vector3(x, 0, y);
    }

}

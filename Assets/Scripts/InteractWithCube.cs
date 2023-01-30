<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
=======
using UnityEditor.Experimental.GraphView;
>>>>>>> Stashed changes
using UnityEngine;


public class InteractWithCube : MonoBehaviour
{
<<<<<<< Updated upstream
    Vector3 initPos;
    private Quaternion initRot;
    public GameObject player;
    public GameObject Cube;
    public GameObject cubeSpot;
    private Vector3 targetPos;
    private Quaternion targetRot;
    private bool isGrabbed;
=======
    [SerializeField] private Transform player;
    [SerializeField] private GameObject _camera;
    


    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Transform _transform;
    private bool isGrabbed;
    private float distance;
    

>>>>>>> Stashed changes
    public bool IsGrabbed => isGrabbed;
    private bool flag = false;
    public GameObject Canvas;
    public GameObject Aim;

    private void Start()
    {
<<<<<<< Updated upstream
        Canvas.SetActive(false);
        initPos = transform.position;
        targetPos = cubeSpot.transform.position;
        targetRot = cubeSpot.transform.rotation = Quaternion.identity;
=======
        _transform = transform;
        initialPosition = _transform.position;
        initialRotation = _transform.rotation;
>>>>>>> Stashed changes
    }
    public void Grab()
    {
<<<<<<< Updated upstream
        initPos = transform.position;
        Cube.transform.SetParent(player.transform);
=======
>>>>>>> Stashed changes
        isGrabbed = true;
        distance = Vector3.Distance(player.position, _transform.position);
    }
<<<<<<< Updated upstream
    public void Release()
    {
        isGrabbed = false;
        Cube.transform.parent= null;
        isGrabbed = false;
        if (flag == false)
        {
            transform.position = initPos;
            transform.rotation = initRot;
        }
    }
    private void OnTriggerStay(Collider collider)
    {
        if ((collider.gameObject.CompareTag("cubeSpot")))
        {
            
            transform.SetPositionAndRotation(new Vector3(
                targetPos.x,
                targetPos.y,
                targetPos.z
                ), targetRot);
            flag = true;
            Invoke(nameof(WinGame), 2);
            
        }
=======

    private void Update()
    {
        if (isGrabbed) 
        {
            var direction = _camera.transform.forward;
            _transform.position = (player.position + direction * distance);
        }
        else
        {
            if (!isGameFinished)
            {
                _transform.SetPositionAndRotation(initialPosition, initialRotation);
            }
        }
    }
    public void Release()
    {
        isGrabbed = false;
>>>>>>> Stashed changes
    }

    private void WinGame(){
        Aim.SetActive(false);
        Canvas.SetActive(true);
        Cursor.visible = true;
    }

}

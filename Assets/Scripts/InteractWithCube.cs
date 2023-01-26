using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractWithCube : MonoBehaviour
{
    Vector3 initPos;
    private Quaternion initRot;
    public GameObject player;
    public GameObject Cube;
    public GameObject cubeSpot;
    private Vector3 targetPos;
    private Quaternion targetRot;
    private bool isGrabbed;
    public bool IsGrabbed => isGrabbed;
    private bool flag = false;
    public GameObject Canvas;

    private void Start()
    {
        Canvas.SetActive(false);
        initPos = transform.position;
        targetPos = cubeSpot.transform.position;
        targetRot = cubeSpot.transform.rotation = Quaternion.identity;
    }
    public void Grab()
    {
        initPos = transform.position;
        Cube.transform.SetParent(player.transform);
        isGrabbed = true;
    }
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
        if ((collider.gameObject.tag == "cubeSpot"))
        {
            Debug.Log("This works");

            transform.position = new Vector3(
                targetPos.x,
                targetPos.y,
                targetPos.z
                );
            transform.rotation = targetRot;
            flag = true;
            Invoke("WinGame", 2);
            
        }
    }

    private void WinGame(){
        Canvas.SetActive(true);
            Cursor.visible = true;
    }

}

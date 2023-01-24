using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bounce : MonoBehaviour
{
    Vector3 initPos;
    

    void Awake()
    {
        initPos = transform.position;
        
    }

    void Update()
    {
            transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time) + initPos.y, initPos.z);
            
    }

    private void LateUpdate()
    {
        if(Mathf.Sin(Time.time) + initPos.y > (initPos.y))
        {
            transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time) + initPos.y, initPos.z);
        }
        else if (Mathf.Sin(Time.time) + initPos.y < (initPos.y))
        {
            transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time) + initPos.y, initPos.z);
        }
        else
        {
            transform.position = new Vector3(initPos.x, initPos.y, initPos.z);
        }
    }
}
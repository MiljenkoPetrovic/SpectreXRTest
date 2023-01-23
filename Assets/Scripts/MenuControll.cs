using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControll : MonoBehaviour
{
    public int index;
    public int maxIndex;

    [SerializeField] bool keyDown;
    [SerializeField] RectTransform rectTransform;
    bool isPressUp, isPressDown, isPressConfirm;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        isPressUp = isPressDown = false;
    }

    public void onPressUp() { isPressUp = true; }
    public void onReleaseUp()
    {
        isPressUp = false;
    }
    public void onPressDown() { isPressDown = true; }
    public void onReleaseDown()
    {
        isPressDown = false;
    }
    public void onPressConfirm() { isPressConfirm = true; }
    public void onReleaseConfirm()
    {
        isPressConfirm = false;
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}

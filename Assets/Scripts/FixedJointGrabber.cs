using UnityEngine;

public class FixedJointGrabber : MonoBehaviour, IGrabbable
{
    [SerializeField] private Rigidbody _camera;

    private bool isGrabbed;
    private FixedJoint fixedJoint;
    
    public void Grab()
    {
        if (isGrabbed) return;

        fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = _camera;
        isGrabbed = true;
    }

    public void Release()
    {
        if (!isGrabbed) return;

        Destroy(fixedJoint);
        isGrabbed = false;
    }
}

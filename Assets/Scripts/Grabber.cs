using UnityEngine;

public class Grabber : CheckingForObjects
{
    private IGrabbable grabbable;

    protected override void ObjectFound(RaycastHit hit)
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit.transform.TryGetComponent<IGrabbable>(out grabbable);
            if (grabbable == null) return;
            grabbable.Grab();
        }

        if (grabbable == null) return;

        if (Input.GetMouseButtonUp(0))
        {
            grabbable.Release();
        }
    }
}

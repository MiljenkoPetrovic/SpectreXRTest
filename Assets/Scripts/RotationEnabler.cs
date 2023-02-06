using UnityEngine;

public class RotationEnabler : CheckingForObjects
{
    private RotateSpectreCubes rotate;

    protected override void ObjectFound(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent<RotateSpectreCubes>(out rotate))
        {
            if (rotate.enabled)
            {
                rotate.enabled = false;
            }
        }
    }

    protected override void NotHit()
    {
        if (rotate != null)
        {
            if (!rotate.enabled)
            {
                rotate.enabled = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the attached GameObject to wrap around to the other side of the game screen.
/// </summary>
public class ScreenWrap : MonoBehaviour
{
    [SerializeField] private Camera screenCam;

    private void Wrap()
    {
        throw new System.NotImplementedException();
    }

    private Vector3 ObjPosToScreenPoint()
    {
        //bottom-left is (0, 0), top-right is (Camera.pixelWidth, Camera.pixelHeight)
        return screenCam.WorldToScreenPoint(transform.position);
    }
}

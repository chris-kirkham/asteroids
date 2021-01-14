using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the attached GameObject to wrap around to the other side of the game screen.
/// </summary>
public class ScreenWrap : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        //find the main camera
        cam = Camera.main;
        if(cam == null) throw new System.NullReferenceException("No main camera found for screen wrapping!");
    }

    private void Update()
    {
        Wrap();
    }

    private void Wrap()
    {
        //bottom-left is (0, 0), top-right is (Camera.pixelWidth, Camera.pixelHeight)
        Vector3 objScreenPoint = cam.WorldToScreenPoint(transform.position);
        
        if (IsPointOffscreen(objScreenPoint))
        {
            transform.position = cam.ScreenToWorldPoint(GetWrappedScreenPoint(objScreenPoint));
        }
    }
    
    private bool IsPointOffscreen(Vector3 screenPoint)
    {
        return (screenPoint.x < 0 || screenPoint.x > cam.pixelWidth || screenPoint.y < 0 || screenPoint.y > cam.pixelHeight);
    }

    private Vector3 GetWrappedScreenPoint(Vector3 screenPoint)
    {
        float width = cam.pixelWidth;
        float height = cam.pixelHeight;
        Vector3 wrappedScreenPoint = screenPoint;

        if (screenPoint.x > width)
        {
            wrappedScreenPoint.x %= width;
        }
        else if(screenPoint.x < 0)
        {
            //almost certainly could just add the screen width once, but do this in case the object has somehow gone >-1 screen width offscreen
            do
            {
                wrappedScreenPoint.x += width;
            }
            while (wrappedScreenPoint.x < 0);
        }

        if (screenPoint.y > height)
        {
            wrappedScreenPoint.y %= height;
        }
        else if (screenPoint.y < 0)
        {
            //same as with width, in case obj is >-1 height offscreen
            do
            {
                wrappedScreenPoint.y += height;
            }
            while (wrappedScreenPoint.y < 0);
        }

        return wrappedScreenPoint;
    }

}

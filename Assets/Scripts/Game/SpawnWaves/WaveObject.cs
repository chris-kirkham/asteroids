using System;
using UnityEngine;

/// <summary>
/// Indicates that the attached GameObject is part of a spawn wave. The Removed event should be subscribed to by a Wave, 
/// so the Wave can know when its objects are destroyed.
/// </summary>
public class WaveObject : MonoBehaviour
{
    public event Action Removed;

    private void OnDisable()
    {
        Removed?.Invoke();
    }
}

using System;
using UnityEngine;

/// <summary>
/// Represents an object which is part of a spawn wave.
/// </summary>
public class WaveObject : MonoBehaviour
{
    public int waveObjID;
    public event Action<int> Removed; //called when this object is disabled or destroyed

    private void OnDisable()
    {
        Removed?.Invoke(waveObjID);
    }
}

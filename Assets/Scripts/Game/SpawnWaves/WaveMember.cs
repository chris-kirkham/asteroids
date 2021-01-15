using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Indicates that the attached GameObject is part of a spawn wave. The Removed event should be subscribed to by a Wave, 
    /// so the Wave can know when its objects are destroyed.
    /// </summary>
    public class WaveMember : MonoBehaviour
    {
        public event Action RemovedFromWave;

        private void OnDisable()
        {
            RemovedFromWave?.Invoke();
        }
    }
}
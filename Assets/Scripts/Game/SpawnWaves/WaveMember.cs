using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Indicates that the attached (killable) GameObject is part of a spawn wave. The Removed event should be subscribed to by a Wave, 
    /// so the Wave can know when its objects are killed.
    /// </summary>
    [RequireComponent(typeof(IKillable))]
    public class WaveMember : MonoBehaviour
    {
        //components
        private IKillable killable;

        //events
        public event Action RemovedFromWave;

        private void Awake()
        {
            killable = GetComponent<IKillable>();
        }

        private void OnEnable()
        {
            killable.Killed += RemoveFromWave;
        }

        private void OnDisable()
        {
            killable.Killed -= RemoveFromWave;
        }

        private void RemoveFromWave()
        {
            RemovedFromWave?.Invoke();
        }
    }
}
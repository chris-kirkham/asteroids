using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Represents a "wave" or level in the game
    /// </summary>
    public class Wave : MonoBehaviour
    {
        [Tooltip("The list of actions to be performed this wave.")]
        [SerializeField] private List<GameAction> waveActions;

        [Tooltip("The time, in seconds, from instantiation until this wave's actions begin.")]
        [SerializeField] [Min(0)] private float waveStartDelay;

        private void Awake()
        {
            Invoke("DoWave", waveStartDelay);
        }

        private void DoWave()
        {
            foreach (GameAction waveAction in waveActions) waveAction.Execute();
        }
    }
}
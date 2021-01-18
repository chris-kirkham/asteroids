using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Invokes a "victory" event when the game is won.
    /// </summary>
    public class VictoryManager : MonoBehaviour
    {
        //inspector
        [SerializeField] private WaveManager waveManager = null;

        //events
        public event Action Victory;

        private void OnEnable()
        {
            waveManager.AllWavesEnded += OnVictory;
        }

        private void OnDisable()
        {
            waveManager.AllWavesEnded -= OnVictory;
        }

        private void OnVictory()
        {
            Victory?.Invoke();
        }
    }
}
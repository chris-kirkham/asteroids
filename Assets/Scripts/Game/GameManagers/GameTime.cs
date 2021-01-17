using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Tracks the elapsed game time from the start of the first spawn wave.
    /// </summary>
    public class GameTime : MonoBehaviour
    {
        //inspector
        [SerializeField] private WaveManager waveManager = null;

        //private
        public float CurrGameTime { get; private set; } = 0;
        private bool timerActive = false;

        private void OnEnable()
        {
            waveManager.FirstWaveStarted += StartGameTimer;
            waveManager.AllWavesEnded += StopGameTimer;
        }

        private void OnDisable()
        {
            waveManager.FirstWaveStarted -= StartGameTimer;
            waveManager.AllWavesEnded -= StopGameTimer;
        }

        private void Update()
        {
            if (timerActive) CurrGameTime += Time.deltaTime;
        }

        private void StartGameTimer()
        {
            timerActive = true;
        }

        private void StopGameTimer()
        {
            timerActive = false;
        }

    }
}
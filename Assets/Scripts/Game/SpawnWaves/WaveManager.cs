using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Manages spawn waves during gameplay - spawns new waves when one ends.
    /// </summary>
    public class WaveManager : MonoBehaviour
    {
        //inspector variables
        [SerializeField] private List<Wave> waves = null;
        [SerializeField] [Min(0)] private float timeBetweenWaves = 0f;

        //private variables
        private int currWave;

        //Wave management events
        public event Action WaveStarted;
        public event Action<int> WaveNStarted;
        public event Action<int> WaveNEnded;
        public event Action FirstWaveStarted;
        public event Action AllWavesEnded;

        private void Start()
        {
            currWave = 0;
            FirstWaveStarted?.Invoke();
            StartCoroutine(Coroutine_StartNewWave(timeBetweenWaves));
        }

        private IEnumerator Coroutine_StartNewWave(float delay)
        {
            WaveStarted?.Invoke();
            WaveNStarted?.Invoke(currWave);
            
            yield return new WaitForSeconds(delay);

            if (currWave < waves.Count)
            {
                //start new wave
                Wave wave = Instantiate(waves[currWave], waves[currWave].transform.position, waves[currWave].transform.rotation);
                wave.WaveEnded += EndWave;
            }
        }

        private void EndWave()
        {
            WaveNEnded?.Invoke(currWave);

            currWave++;
            if (currWave < waves.Count)
            {
                StartCoroutine(Coroutine_StartNewWave(timeBetweenWaves));
            }
            else //all waves ended
            {
                AllWavesEnded?.Invoke();
            }
        }
    }
}
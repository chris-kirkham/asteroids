using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class WaveManager : MonoBehaviour
    {
        //inspector variables
        [SerializeField] List<Wave> waves;

        //private variables
        private int currWave;

        //Wave management events
        public event Action<int> WaveEnded;

        private void Awake()
        {
            currWave = 0;
        }

        private void OnWaveEnded()
        {
            WaveEnded?.Invoke(currWave);
            currWave++;
        }

    }
}
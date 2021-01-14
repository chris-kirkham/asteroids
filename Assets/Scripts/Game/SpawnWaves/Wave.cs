using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Represents a "wave" or level in the game
    /// </summary>
    public class Wave : MonoBehaviour
    {
        private struct WaveSpawn
        {
            public GameObject objectToSpawn;
            public int numberToSpawn;
        }
        
        //inspector parameters
        [SerializeField] private List<WaveSpawn> waveSpawns = null;

        //private variables
        private int numRemainingInWave;

        //events
        public event Action WaveEnded;

        private void Awake()
        {
            InitNumRemaining();
            DoWave();
        }

        private void DoWave()
        {
            InitNumRemaining();
        
            foreach(WaveSpawn waveSpawn in waveSpawns)
            {
                for(int i = 0; i < waveSpawn.numberToSpawn; i++)
                {
                    SpawnWaveObject(waveSpawn.objectToSpawn);
                }
            }
        }
        
        private void SpawnWaveObject(GameObject objectToSpawn)
        {
            GameObject waveObject = Instantiate(objectToSpawn);
            if (objectToSpawn.GetComponent<WaveObject>()) objectToSpawn.AddComponent<WaveObject>();
            waveObject.GetComponent<WaveObject>().Removed += DecrementNumRemaining;
            waveObject.GetComponent<WaveObject>().Removed += CheckWaveEnded;
        }

        private void InitNumRemaining()
        {
            numRemainingInWave = 0;
            foreach (WaveSpawn waveSpawn in waveSpawns)
            {
               numRemainingInWave += waveSpawn.numberToSpawn;
            }
        }

        private void DecrementNumRemaining()
        {
            numRemainingInWave--;
        }

        private void CheckWaveEnded()
        {
            if (numRemainingInWave <= 0) WaveEnded?.Invoke();
        }
    }
}
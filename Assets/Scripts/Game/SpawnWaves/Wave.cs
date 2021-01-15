using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Represents a "wave" or level in the game. 
    /// 
    /// -------HOW TO CONSTRUCT A WAVE--------
    /// Any child objects of this script's GameObject which have the WaveMember component are considered part of the wave.
    /// This script subscribes to the events that each wave member sends out, and tracks how many are left in the wave.
    /// </summary>
    public class Wave : MonoBehaviour
    {
        //private variables
        private int numRemainingInWave;

        //events
        public event Action WaveEnded;

        private void Awake()
        {
            numRemainingInWave = 0; //this will be incremented for each object tracked
        
            //all child objects of this object which have WaveMember components will be tracked
            foreach(Transform child in transform)
            {
                StartTrackingWaveMember(child.gameObject);
            }
        }

        private void StartTrackingWaveMember(GameObject obj)
        {
            //if object is a wave member
            WaveMember memberComponent = obj.GetComponent<WaveMember>();
            if(memberComponent != null)
            {
                numRemainingInWave++;

                memberComponent.RemovedFromWave += DecrementNumRemaining;
                memberComponent.RemovedFromWave += CheckWaveEnded;
            }

            ICreatesNewWaveMembers createsMembersComponent = obj.GetComponent<ICreatesNewWaveMembers>();
            if (createsMembersComponent != null) createsMembersComponent.CreatedNewWaveMembers += StartTrackingWaveMembers;
        }

        private void StartTrackingWaveMembers(List<GameObject> objs)
        {
            foreach (GameObject obj in objs) StartTrackingWaveMember(obj);
        }

        private void DecrementNumRemaining()
        {
            numRemainingInWave--;
        }

        private void CheckWaveEnded()
        {
            if (numRemainingInWave <= 0) DoWaveEnded();
        }

        private void DoWaveEnded()
        {
            WaveEnded?.Invoke();

            Destroy(gameObject);
        }
    }
}
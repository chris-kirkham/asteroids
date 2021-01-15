using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class PlayerHealth : Health
    {
        [SerializeField] private WaveManager waveManager = null;
        [SerializeField] [Min(0)] private float invlunTimeOnWaveStart = 1f;

        private void OnEnable()
        {
            waveManager.WaveStarted += MakeInvulnerableOnWaveStart;
        }

        private void OnDisable()
        {
            waveManager.WaveStarted -= MakeInvulnerableOnWaveStart;
        }

        private void MakeInvulnerableOnWaveStart()
        {
            StartCoroutine(Coroutine_MakeInvulnerableForNSeconds(invlunTimeOnWaveStart));
        }

        private IEnumerator Coroutine_MakeInvulnerableForNSeconds(float invulnTime)
        {
            isInvulnerable = true;
            InvokeBecameInvulnerable();
            
            yield return new WaitForSeconds(invulnTime);
            
            isInvulnerable = false;
            InvokeBecameVulnerable();
        }
    }
}
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

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if (currHealth <= 0) Kill();
        }

        private IEnumerator Coroutine_MakeInvulnerableForNSeconds(float invulnTime)
        {
            isInvulnerable = true;
            InvokeBecameInvulnerable();
            
            yield return new WaitForSeconds(invulnTime);
            
            isInvulnerable = false;
            InvokeBecameVulnerable();
        }

        public void MakeInvulnerableForNSeconds(float invulnTime)
        {
            StartCoroutine(Coroutine_MakeInvulnerableForNSeconds(invulnTime));
        }

        private void MakeInvulnerableOnWaveStart()
        {
            StartCoroutine(Coroutine_MakeInvulnerableForNSeconds(invlunTimeOnWaveStart));
        }

        
    }
}
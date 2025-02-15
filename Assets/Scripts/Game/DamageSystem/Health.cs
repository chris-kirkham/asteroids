﻿using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Manages the health of a GameObject; handles damage taken.
    /// </summary>
    public class Health : MonoBehaviour, IDamageable, IKillable
    {
        //inspector parameters
        [SerializeField] [Min(0)] protected int initialHealth;

        //public
        public bool isInvulnerable = false;

        //protected
        protected int currHealth;

        //Health-related events
        public event Action TookDamage;
        public event Action<int> TookNDamage;
        public event Action Killed;
        public event Action BecameInvulnerable;
        public event Action BecameVulnerable;

        protected virtual void Awake()
        {
            currHealth = initialHealth;
        }

        public virtual void TakeDamage(Damager damager)
        {
            TakeDamage(damager.Damage);
        }

        public virtual void TakeDamage(int damage)
        {
            if(!isInvulnerable)
            {
                currHealth -= damage;
                TookDamage?.Invoke();
                TookNDamage?.Invoke(damage);
                if (currHealth <= 0) Kill();
            }
        }

        public virtual void Kill()
        {
            Killed?.Invoke();
        }

        public int GetCurrentHealth()
        {
            return currHealth;
        }

        /* Protected event functions, so events can be invoked from derived classes */
        protected void InvokeTookDamage()
        {
            TookDamage?.Invoke();
        }

        protected void InvokeTookNDamage(int damage)
        {
            TookNDamage?.Invoke(damage);
        }

        protected void InvokeKilled()
        {
            Killed?.Invoke();
        }

        protected void InvokeBecameInvulnerable()
        {
            BecameInvulnerable.Invoke();
        }

        protected void InvokeBecameVulnerable()
        {
            BecameVulnerable.Invoke();
        }
    }
}
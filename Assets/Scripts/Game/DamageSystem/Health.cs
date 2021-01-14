using System;
using UnityEngine;

namespace Game
{
    public class Health : MonoBehaviour, IDamageable, IKillable
    {
        //inspector parameters
        [SerializeField] [Min(0)] protected int initialHealth;
        
        //private variables
        protected int currHealth;
        protected bool isInvulnerable = false;

        //Health-related events
        public event Action TookDamage;
        public event Action<int> TookNDamage;
        public event Action Killed;

        protected void Awake()
        {
            currHealth = initialHealth;
        }

        public virtual void Damage(int damage)
        {
            currHealth = Mathf.Max(currHealth - damage, 0);
            TookDamage?.Invoke();
            TookNDamage?.Invoke(damage);
        }

        public virtual void Kill()
        {
            Killed?.Invoke();
        }

        public int GetCurrentHealth()
        {
            return currHealth;
        }
    }
}
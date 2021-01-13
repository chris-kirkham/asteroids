using System;
using UnityEngine;

namespace Game
{
    public abstract class Health : MonoBehaviour, IDamageable, IKillable
    {
        [SerializeField] [Min(0)] protected float maxHealth;
        protected float currHealth;

        //Health-related events
        public event Action Damaged;
        public event Action Killed;

        protected virtual void Awake()
        {
            currHealth = maxHealth;
        }

        public virtual void Damage(float damage)
        {
            currHealth = Mathf.Max(currHealth - damage, 0);
            Damaged?.Invoke();
        }

        public virtual void Kill()
        {
            Killed?.Invoke();
        }
    }
}
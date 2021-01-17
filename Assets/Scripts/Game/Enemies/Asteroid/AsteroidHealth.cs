using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Health variant which automatically destroys the attached object when it is killed - intended for asteroids 
    /// </summary>
    public class AsteroidHealth : Health
    {
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            if (currHealth <= 0) Kill();
        }

        public override void Kill()
        {
            base.Kill();
            Destroy(gameObject);
        }
    }
}
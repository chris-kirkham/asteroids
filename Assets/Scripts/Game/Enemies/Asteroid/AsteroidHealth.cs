using System;
using UnityEngine;

namespace Game
{
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
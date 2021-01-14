using System;
using UnityEngine;

namespace Game
{
    public class AsteroidHealth : Health
    {
        public override void Damage(int damage)
        {
            base.Damage(damage);
            if (currHealth <= 0) Kill();
        }

        public override void Kill()
        {
            base.Kill();
            Destroy(gameObject);
        }
    }
}
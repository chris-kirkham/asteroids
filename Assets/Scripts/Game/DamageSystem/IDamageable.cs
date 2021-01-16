using System.Collections;
using System;
using UnityEngine;

namespace Game
{
    /// <summary>An object which can be damaged.</summary>
    public interface IDamageable
    {
        void TakeDamage(Damager damager);

        void TakeDamage(int damage);
    }
}
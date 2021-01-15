using System.Collections;
using System;
using UnityEngine;

namespace Game
{
    /// <summary>An object which can be damaged.</summary>
    public interface IDamageable
    {
        event Action TookDamage;
        event Action<int> TookNDamage;

        void Damage(Damager damager);

        void Damage(int damage);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>An object which can be damaged.</summary>
    public interface IDamageable
    {
        void Damage(float damage);
    }
}
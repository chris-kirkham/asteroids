using System;
using UnityEngine;

namespace Game
{
    /// <summary>An object which can be killed.</summary>
    public interface IKillable
    {
        event Action Killed;

        void Kill();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>An object which can be killed.</summary>
    public interface IKillable
    {
        void Kill();
    }
}
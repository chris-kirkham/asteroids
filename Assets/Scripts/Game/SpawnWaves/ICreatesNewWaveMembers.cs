using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// If the wave member can instantiate or otherwise add new objects to its wave, implement this so the wave object can track them 
    /// </summary>
    public interface ICreatesNewWaveMembers
    {
        /// <summary>Should be called with a list of the newly-created wave members on their creation</summary>
        event Action<List<GameObject>> CreatedNewWaveMembers;
    }
}
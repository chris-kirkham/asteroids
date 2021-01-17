using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// An action which takes a GameObject as a parameter in its Execute method. This is the same as Action<GameObject>, 
    /// but reifying it like this allows it to be serialised in the inspector.
    /// </summary>
    public abstract class GameObjectAction : GameAction<GameObject> { }
}
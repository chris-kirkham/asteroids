using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Generic version of the Action class, which represents an action that can be executed within the game. 
    /// This is essentially a stateful variation of the command pattern - 
    /// Actions are instantiated in the game world and manage their own state during gameplay. 
    /// </summary>
    public abstract class GameAction<T> : MonoBehaviour
    {
        public abstract void Execute(T param);
    }
}
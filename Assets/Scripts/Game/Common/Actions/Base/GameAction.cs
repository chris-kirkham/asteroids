using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Represents an action which can be executed within the game. This is essentially a stateful variation of the command pattern - 
    /// Actions are instantiated in the game world and manage their own state during gameplay. 
    /// 
    /// This has some advantages; for example, a player that wants to fire a gun will call a FireGunAction (or whatever name). 
    /// The calling player doesn't need to worry whether the gun has ammo or if its fire rate cooldown has elapsed, 
    /// as this will all be handled within the FireGunAction script. It also makes it easy to swap out actions on the fly 
    /// e.g. if the player collects a new weapon.
    /// </summary>
    public abstract class GameAction : MonoBehaviour
    {
        public abstract void Execute();
    }
}
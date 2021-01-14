using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// The actions (e.g. firing a weapon) the player can perform. Actions are represented by action objects, which can be set via the inspector. 
    /// To be attached to a player's GameObject.
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerActions : MonoBehaviour
    {
        private PlayerInput input;
        
        [SerializeField] private List<GameObjectAction> actions = null;

        private void Awake()
        {
            input = GetComponent<PlayerInput>();

            //instantiate action objects
            for (int i = 0; i < actions.Count; i++) actions[i] = Instantiate(actions[i]);
        }

        private void Update()
        {
            //TEST
            if (input.ActionInputs[0]) actions[0].Execute(gameObject);
        }
    }
}
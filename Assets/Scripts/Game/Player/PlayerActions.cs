using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// The actions (e.g. firing a weapon) the player can perform. Actions are represented by action objects, which can be set via the inspector. 
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
            ExecuteActionInputs();
        }

        private void ExecuteActionInputs()
        {
            for(int i = 0; i < actions.Count; i++)
            {
                if(input.ActionInputs.Count > i && input.ActionInputs[i]) //if an input for this action index exists and if it is activated
                {
                    actions[i].Execute(gameObject);
                }
            }
        }
    }
}
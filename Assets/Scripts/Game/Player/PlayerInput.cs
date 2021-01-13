using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Handles player input by converting raw inputs into player commands.
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        public float TurnInput { get; private set; }
        public float ThrustInput { get; private set; }
        public List<bool> ActionInputs { get; private set; }

        private void Awake()
        {
            ActionInputs = new List<bool> { false, false, false, false };
        }

        private void Update()
        {
            ThrustInput = Input.GetKey(KeyCode.UpArrow) ? 1 : (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);
            TurnInput = Input.GetKey(KeyCode.RightArrow) ? 1 : (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0);
            ActionInputs[0] = Input.GetKey(KeyCode.Space);
        }
    }
}
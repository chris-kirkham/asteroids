using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Handles player input by converting raw inputs into player commands.
    /// </summary>
    [RequireComponent(typeof(PlayerHealth))] //player health; used to disable player input if player is killed 
    public class PlayerInput : MonoBehaviour
    {
        //components
        private PlayerHealth playerHealth;

        //inspector params
        [SerializeField] private bool allowPlayerControl = true;
        [SerializeField] private KeyCode leftTurnKey = KeyCode.LeftArrow;
        [SerializeField] private KeyCode rightTurnKey = KeyCode.RightArrow;
        [SerializeField] private KeyCode forwardThrustKey = KeyCode.UpArrow;
        [SerializeField] private KeyCode reverseThrustKey = KeyCode.DownArrow;
        [SerializeField] private List<KeyCode> actionKeys = new List<KeyCode> { KeyCode.Space };

        //inputs
        public float TurnInput { get; private set; }
        public float ThrustInput { get; private set; }
        public List<bool> ActionInputs { get; private set; }

        private void Awake()
        {
            EnablePlayerControl();
            playerHealth = GetComponent<PlayerHealth>();
            InitActionInputs();
        }

        private void OnEnable()
        {
            playerHealth.Killed += DisablePlayerControl;
        }

        private void OnDisable()
        {
            playerHealth.Killed -= DisablePlayerControl;
        }

        private void Update()
        {
            if (allowPlayerControl) ProcessInputs();
        }

        private void ProcessInputs()
        {
            //thrust inputs
            ThrustInput = Input.GetKey(forwardThrustKey) ? 1 : (Input.GetKey(reverseThrustKey) ? -1 : 0);

            //turn inputs
            TurnInput = Input.GetKey(rightTurnKey) ? 1 : (Input.GetKey(leftTurnKey) ? -1 : 0);

            //action inputs
            for (int i = 0; i < ActionInputs.Count; i++)
            {
                ActionInputs[i] = Input.GetKey(actionKeys[i]);
            }
        }

        //initialises the action input list with size = number of action keys set in the inspector
        private void InitActionInputs()
        {
            ActionInputs = new List<bool>(actionKeys.Count);
            for (int i = 0; i < actionKeys.Count; i++) ActionInputs.Add(false);
        }

        private void DisablePlayerControl()
        {
            allowPlayerControl = false;
            
            //reset all inputs
            ThrustInput = 0;
            TurnInput = 0;
            for (int i = 0; i < ActionInputs.Count; i++)
            {
                ActionInputs[i] = false;
            }
        }

        private void EnablePlayerControl()
        {
            allowPlayerControl = true;
        }
    }
}
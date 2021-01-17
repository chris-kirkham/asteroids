using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Handles input for the restart/quit menu used when the player either wins the game (completes all waves) or gets a game over
    /// </summary>
    public class MenuInput : MonoBehaviour
    {
        //inspector
        [SerializeField] private VictoryManager victoryManager = null;
        [SerializeField] private GameOverManager gameOverManager = null;

        [SerializeField] private KeyCode restartInput = KeyCode.Space;
        public KeyCode RestartInput
        {
            get { return restartInput; }
            private set { restartInput = value; }
        }

        [SerializeField] private KeyCode quitInput = KeyCode.Escape;
        public KeyCode QuitInput
        {
            get { return quitInput; }
            private set { quitInput = value; }
        }

        //properties/private
        public bool MenuInputEnabled { get; private set; }

        //events
        public event Action Restart;
        public event Action Quit;

        private void OnEnable()
        {
            MenuInputEnabled = false;
            victoryManager.Victory += EnableMenuInput; 
            gameOverManager.GameOver += EnableMenuInput;
        }

        private void OnDisable()
        {
            victoryManager.Victory -= EnableMenuInput;
            gameOverManager.GameOver += EnableMenuInput;
        }

        private void Update()
        {
            if(MenuInputEnabled)
            {
                if (Input.GetKeyDown(restartInput)) Restart?.Invoke();
                if (Input.GetKeyDown(quitInput)) Quit?.Invoke();
            }
            
        }

        private void EnableMenuInput()
        {
            MenuInputEnabled = true;
        }
    }
}
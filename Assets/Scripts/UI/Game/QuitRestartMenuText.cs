using Game;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Displays a message with inputs for quitting/restarting the game when the player wins or gets a game over.
    /// </summary>
    [RequireComponent(typeof(MenuInput))]
    public class QuitRestartMenuText : UIText
    {
        [SerializeField] private VictoryManager victoryManager = null;
        [SerializeField] private GameOverManager gameOverManager = null;
        
        private MenuInput input;

        protected override void Awake()
        {
            base.Awake();
            input = GetComponent<MenuInput>();
            text.SetText("");
        }

        private void OnEnable()
        {
            victoryManager.Victory += DisplayText;
            gameOverManager.GameOver += DisplayText;
        }

        private void OnDisable()
        {
            victoryManager.Victory -= DisplayText;
            gameOverManager.GameOver -= DisplayText;
        }

        protected void DisplayText()
        {
            text.SetText(input.RestartInput + " to restart \n" + input.QuitInput + " to quit");
        }
    }
}
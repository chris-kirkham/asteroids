using Game;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Displays "Game over" text onscreen when game over happens.
    /// </summary>
    public class GameOverText : UIText
    {
        [SerializeField] private GameOverManager gameOverManager = null;
        [SerializeField] private string gameOverText = "";

        private void OnEnable()
        {
            text.SetText("");
            gameOverManager.GameOver += DisplayText;
        }

        private void OnDisable()
        {
            gameOverManager.GameOver -= DisplayText;
        }

        private void DisplayText()
        {
            text.SetText(gameOverText);
        }
    }
}
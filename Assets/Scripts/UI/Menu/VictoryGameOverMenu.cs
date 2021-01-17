using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    /// <summary>
    /// Menu for both the victory screen and the game over screen.
    /// </summary>
    [RequireComponent(typeof(MenuInput))]
    public class VictoryGameOverMenu : MonoBehaviour
    {
        private MenuInput input;

        private void Awake()
        {
            input = GetComponent<MenuInput>();
        }

        private void OnEnable()
        {
            input.Restart += RestartGame;
            input.Quit += QuitGame;
        }

        private void OnDisable()
        {
            input.Restart -= RestartGame;
            input.Quit -= QuitGame;
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Watches the player's health, and triggers a game over event when it reaches zero.
    /// </summary>
    public class GameOverManager : MonoBehaviour
    {
        //inspector
        [SerializeField] private PlayerHealth playerHealth = null;

        //events
        public event Action GameOver; 

        private void OnEnable()
        {
            if (playerHealth == null)
            {
                throw new System.NullReferenceException("Game over manager requires a PlayerHealth component.");
            }
            else
            {
                playerHealth.Killed += DoGameOver;
            }
        }

        private void OnDisable()
        {
            if(playerHealth != null)
            {
                playerHealth.Killed -= DoGameOver;
            }
        }

        private void DoGameOver()
        {
            GameOver?.Invoke();
        }
    }
}
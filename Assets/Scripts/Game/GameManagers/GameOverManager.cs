using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;

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
            Debug.Log("GAME OVER!!!!");
        }
    }
}
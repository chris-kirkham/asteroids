using System.Collections;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Respawns the player when its health (lives) decreases.
    /// </summary>
    [RequireComponent(typeof(PlayerHealth))]
    public class RespawnPlayer : MonoBehaviour
    {
        //inspector parameters
        [SerializeField] private Vector2 spawnPosition = Vector2.zero;
        [SerializeField] [Min(0)] private float invulnTime = 0;

        //private variables
        private PlayerHealth playerLives = null; //Health can be used as "lives" by taking each health point to mean one life

        private void Awake()
        {
            playerLives = GetComponent<PlayerHealth>();
        }

        private void OnEnable()
        {
            playerLives.TookDamage += Respawn;
        }

        private void OnDisable()
        {
            playerLives.TookDamage -= Respawn;
        }

        private void Respawn()
        {
            if(playerLives.GetCurrentHealth() > 0) //don't respawn if player has lost all lives (health)
            {
                transform.position = spawnPosition;
                playerLives.MakeInvulnerableForNSeconds(invulnTime);
            }
        }
    }
}
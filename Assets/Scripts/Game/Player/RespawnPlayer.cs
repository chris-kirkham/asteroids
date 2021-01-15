using System.Collections;
using UnityEngine;

namespace Game
{
    public class RespawnPlayer : MonoBehaviour
    {
        //inspector parameters
        [SerializeField] private GameObject player;
        [SerializeField] private Vector2 spawnPosition = Vector2.zero;
        [SerializeField] [Min(0)] private float invulnTime = 0;

        //private variables
        private Health playerLives = null; //Health can be used as "lives" by taking each health point to mean one life

        private void Awake()
        {
            playerLives = player.GetComponent<Health>();
            if(playerLives == null)
            {
                throw new System.NullReferenceException("Given player GameObject must have a life info component to know when to respawn it!");
            }
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
            //TODO
            throw new System.NotImplementedException();
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Game
{
    public class RespawnPlayer : MonoBehaviour
    {
        //inspector parameters
        //[SerializeField] private GameObject player;
        [SerializeField] private Health playerLives = null; //Health can be used as "lives" by letting each health point mean one life
        [SerializeField] private Vector2 spawnPosition = Vector2.zero;
        [SerializeField] [Min(0)] private float invulnTime = 0;


        private void Respawn()
        {
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject objectToSpawn;
        [SerializeField] [Min(1)] private int numberToSpawn;
        [SerializeField] private SpawnPositionMode spawnPositionMode;
        private enum SpawnPositionMode { OnObject, ColliderAABB, WithinScreen };

    }
}
﻿using UnityEngine;

namespace Game
{
    /// <summary>
    /// Moves an asteroid at a constant speed in a random direction (determined on startup) 
    /// </summary>
    public class AsteroidMovement : MonoBehaviour
    {
        [SerializeField] [Min(0)] private float moveSpeed = 1;

        private Vector2 moveDirection;

        private void Awake()
        {
            moveDirection = GetRandomInitialMoveDirection();
        }

        private void Update()
        {
            ApplyMove();
        }

        private void ApplyMove()
        {
            transform.position += (Vector3)moveDirection.normalized * moveSpeed * Time.deltaTime;
        }

        private Vector2 GetRandomInitialMoveDirection()
        {
            return Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward) * Vector2.right;
        }
    }
}
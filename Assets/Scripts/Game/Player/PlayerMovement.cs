using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>Moves the player based on input.</summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody rb;
        private PlayerInput input;
        
        [Header("Thrust settings")]
        [SerializeField] private float thrustForce;
        [SerializeField] private float maxSpeed;
        
        [Header("Turn settings")]
        [SerializeField] private float turnSpeed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            input = GetComponent<PlayerInput>();
        }

        private void FixedUpdate()
        {
            ApplyTurnInput();
            ApplyThrustInput();
            ClampMaxSpeed();
        }

        private void ApplyTurnInput()
        {
            rb.AddTorque(transform.up * input.TurnInput * turnSpeed, ForceMode.Acceleration);
        }

        private void ApplyThrustInput()
        {
            rb.AddForce(transform.forward * input.ThrustInput * thrustForce, ForceMode.Force);
        }

        private void ClampMaxSpeed()
        {
            if (rb.velocity.magnitude > maxSpeed) rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
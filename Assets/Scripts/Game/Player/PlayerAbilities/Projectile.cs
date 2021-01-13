using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A projectile which moves through the game world at a constant speed and direction, and destroys itself when it reaches its maximum distance or hits something.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour, IKillable
{
    //private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;
    [SerializeField] private float damage;
    
    private Vector2 origin;

    void Awake()
    {
        origin = transform.position;
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        DestroyIfTravelledMaxDistance();
    }

    private void DestroyIfTravelledMaxDistance()
    {
        if (Vector2.Distance(origin, transform.position) > maxDistance) Kill();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<IDamageable>()?.Damage(damage);
        Kill();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}

using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    [SerializeField] private Rigidbody2D projectileRigidbody;
    public Rigidbody2D ProjectileRigidbody => projectileRigidbody;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Debug.Log("touché");
        }
    }
}
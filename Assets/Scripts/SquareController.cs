using System;
using UnityEngine;

public class SquareController : MonoBehaviour {
    [SerializeField] private Rigidbody2D squareRigidbody;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float jumpPower = 1000f;

    private bool grounded;

    void Start() {
        grounded = false;
    }
    
    // Update is called once per frame
    void Update() {
        Vector2 movementVector = new Vector2(
            Input.GetAxis("Horizontal"),
            0f);

        if (movementVector.magnitude >= 0.2f) {
            movementVector.Normalize();

            squareRigidbody.AddForce(movementVector * (speed * Time.deltaTime));
        }

        if (Input.GetButtonUp("Jump") && grounded)
            squareRigidbody.AddForce(Vector2.up * jumpPower);

        if (Input.GetButtonDown("MaNouvelleTouche"))
            Debug.Log("coucou");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("FinDeNiveau"))
            Debug.Log("gagné!");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(Vector3.Dot(other.contacts[0].normal, Vector3.up));
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Floor")
            && Vector3.Dot(other.contacts[0].normal, Vector3.up) > 0.9f) {
            grounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Floor")
            && other.contactCount > 0
            && Vector3.Dot(other.contacts[0].normal, Vector3.up) > 0.9f) {
            grounded = false;
        }
    }
}

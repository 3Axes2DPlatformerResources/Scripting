using UnityEngine;

public class SquareController : MonoBehaviour {
    [SerializeField] private Rigidbody2D squareRigidbody;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float jumpPower = 1000f;

    // Update is called once per frame
    void Update() {
        Vector2 movementVector = new Vector2(
            Input.GetAxis("Horizontal"),
            0f);

        if (movementVector.magnitude >= 0.2f) {
            movementVector.Normalize();

            squareRigidbody.AddForce(movementVector * (speed * Time.deltaTime));
        }

        if (Input.GetButtonUp("Jump"))
            squareRigidbody.AddForce(Vector2.up * jumpPower);

        if (Input.GetButtonDown("MaNouvelleTouche"))
            Debug.Log("coucou");
    }
}

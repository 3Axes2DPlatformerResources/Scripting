using UnityEngine;

public class SquareController : MonoBehaviour {
    [SerializeField] private Rigidbody2D squareRigidbody;
    public Rigidbody2D SquareRigidbody => squareRigidbody;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private ParticleSystem jumpParticleSystem;
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float jumpPower = 1000f;

    public int CoinCounter { get; private set; }
    public int LifeCounter { get; private set; }
    private Transform respawnTransform;

    private bool grounded;

    void Start() {
        grounded = false;
        CoinCounter = 0;
        LifeCounter = 3;
        GameManager.LifeDisplayController.ChangeText(LifeCounter);
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

        if (Input.GetButtonUp("Jump") && grounded) {
            jumpParticleSystem.Play();
            squareRigidbody.AddForce(Vector2.up * jumpPower);
        }

        if (Input.GetButtonDown("MaNouvelleTouche"))
            Debug.Log("coucou");
    }

    public void FindRespawnPoint() {
        respawnTransform = GameObject.Find("SpawnPoint").transform;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("FinDeNiveau"))
            Debug.Log("gagné!");
        else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            TakeDamage();
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Coin")) {
            CoinCounter++;
            other.gameObject.GetComponent<CoinController>().HandleDestruction();
            GameManager.CoinDisplayController.ChangeText(CoinCounter);
        }
    }

    public void TakeDamage() {
        Respawn();
        LifeCounter--;
        GameManager.LifeDisplayController.ChangeText(LifeCounter);
        audioSource.Play();
    }

    public void Respawn() {
        squareRigidbody.MovePosition(respawnTransform.position);
        squareRigidbody.velocity = Vector2.zero;
    }
    

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Floor")
            && Vector3.Dot(other.GetContact(0).normal, Vector3.up) > 0.9f) {
            grounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Floor")) {
            grounded = false;
        }
    }
}

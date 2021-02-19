using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Transform squareTransform;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float movementDuration = 2f;
    private bool isGoingRight;
    private float timer;
    
    private float triggerTimer;
    private bool hasTriggerBeenActivated;

    private Vector3 movementVector;
    
    void Start() {
        isGoingRight = true;
        timer = 0f;
        triggerTimer = 0f;
        hasTriggerBeenActivated = false;
        movementVector = new Vector3(0.1f * speed, 0f, 0f);
    }

    void Update() {
        CheckTrigger();
        //MoveSquare();
    }

    private void CheckTrigger() {
        triggerTimer += Time.deltaTime;
        if (triggerTimer > 5f && !hasTriggerBeenActivated) {
            hasTriggerBeenActivated = true;
            animator.SetTrigger("StartMovement");
            animator.SetInteger("MonEntier", 20);
        }
    }

    private void MoveSquare() {
        // Check direction
        timer += Time.deltaTime;
        if (timer > movementDuration) {
            timer = 0f;
            isGoingRight = !isGoingRight;
            /* ^ équivalent à
             if (isGoingRight) isGoingRight = false;
            else isGoingRight = true; */
        }

        // Déplacement
        if (isGoingRight)
            squareTransform.position += movementVector;
        else
            squareTransform.position -= movementVector;
    }
}

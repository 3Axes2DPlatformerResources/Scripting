using UnityEngine;

public class EnemyController : MonoBehaviour {
        [SerializeField] private Transform enemyTransform;
        [SerializeField] private Vector2 direction;
        [SerializeField] private float amplitude = 2f;

        private Vector2 initialPosition;
        private Vector3 currentDirection;

        private void Start() {
                initialPosition = enemyTransform.position;
                currentDirection = direction;
        }
        
        private void Update() {
                enemyTransform.position += currentDirection * Time.deltaTime;
                
                if (Vector3.Distance(enemyTransform.position, initialPosition) > amplitude)
                        currentDirection = -currentDirection;
        }
}
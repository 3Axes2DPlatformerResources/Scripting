using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour {
        [SerializeField] private Transform enemyTransform;
        [SerializeField] private Vector2 direction;
        [SerializeField] private float amplitude = 2f;
        private GameObject projectilePrefab;

        private Vector2 initialPosition;
        private Vector3 currentDirection;
        private float timer;

        private void Start() {
                initialPosition = enemyTransform.position;
                currentDirection = direction;
                timer = 0f;
                projectilePrefab = Resources.Load<GameObject>("Projectile");
        }
        
        private void Update() {
                enemyTransform.position += currentDirection * Time.deltaTime;
                timer += Time.deltaTime;
                
                if (Vector3.Distance(enemyTransform.position, initialPosition) > amplitude)
                        currentDirection = -currentDirection;
        }

        public void ShootPlayer() {
                GameObject projectile = Instantiate(projectilePrefab, enemyTransform.position, Quaternion.identity);
                Vector2 differencePosition = GameManager.SquareController.SquareRigidbody.position -
                                             (Vector2) enemyTransform.position;
                projectile.GetComponent<ProjectileController>().ProjectileRigidbody.AddForce(
                        Vector3.Normalize(differencePosition) * 1000f);
        }
}
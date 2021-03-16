using UnityEngine;

public class EnemyDetectionZoneController : MonoBehaviour {
        [SerializeField] private EnemyController enemyController;
        
        private void OnTriggerEnter2D(Collider2D other) {
                if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
                        enemyController.ShootPlayer();
                }
        }
}
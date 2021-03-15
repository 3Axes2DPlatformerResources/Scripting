using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour {
        [SerializeField] private Transform enemyTransform;
        [SerializeField] private Vector2 direction;
        [SerializeField] private float amplitude = 2f;
        private GameObject projectilePrefab;

        private Coroutine coroutine;

        private Vector2 initialPosition;
        private Vector3 currentDirection;
        private float timer;

        private void Start() {
                initialPosition = enemyTransform.position;
                currentDirection = direction;
                timer = 0f;
                projectilePrefab = Resources.Load<GameObject>("Projectile");
                coroutine = StartCoroutine(MaCoroutine());
        }
        
        private void Update() {
                enemyTransform.position += currentDirection * Time.deltaTime;
                timer += Time.deltaTime;
                
                if (Vector3.Distance(enemyTransform.position, initialPosition) > amplitude)
                        currentDirection = -currentDirection;

                if (((int) timer) % 5 == 0)
                        Instantiate(projectilePrefab, enemyTransform.position, Quaternion.identity);
        }

        private IEnumerator MaCoroutine() {
                for (int i = 5; i > 0; i--)
                {
                        yield return new WaitForSeconds(i);
                        Debug.Log("coucou");
                }
        }
}
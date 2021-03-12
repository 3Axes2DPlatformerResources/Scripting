using UnityEngine;

public class EndLevelController : MonoBehaviour {
    [SerializeField] private string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            GameManager.ChangeScene(sceneToLoad);
    }
}

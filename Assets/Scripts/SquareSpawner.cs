using UnityEngine;

public class SquareSpawner : MonoBehaviour {
    [SerializeField] private Transform squaresParent;
    [SerializeField] private GameObject squarePrefab;

    private void Start() {
        // Quaternion pour éviter Gimbal Lock
        Instantiate(
            squarePrefab,
            new Vector3(1f, 1f, 0f),
            Quaternion.Euler(new Vector3(0f, 0f, 45f)),
            squaresParent);
        Instantiate(
            squarePrefab,
            new Vector3(0f, 0f, 0f),
            Quaternion.Euler(new Vector3(0f, 0f, 60f)),
            squaresParent);
        Instantiate(
            squarePrefab,
            new Vector3(-1f, 2f, 0f),
            Quaternion.Euler(new Vector3(0f, 0f, 70f)),
            squaresParent);
    }
}
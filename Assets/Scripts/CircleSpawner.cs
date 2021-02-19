using System.Collections.Generic;
using UnityEngine;

public class CircleSpawner : MonoBehaviour {
    [SerializeField] private GameObject prefab;
    [SerializeField] private int numberOfSquares = 6;
    [SerializeField] private float radius = 2f;
    [SerializeField] private Vector3 center;

    private List<GameObject> squares;

    void Start() {
        squares = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destruction tous les carrés déjà créés
        foreach (GameObject square in squares) {
            Destroy(square);
        }
        
        for (int i = 0; i < numberOfSquares; i++) {
            // Calcul de l'angle
            float angle = Mathf.PI * 2 / numberOfSquares * i;
            
            // Calcul de la position du point sur le cercle
            Vector3 position = new Vector3(
                radius * Mathf.Cos(angle),
                radius * Mathf.Sin(angle),
                0f);
            
            // Instantiation du carré
            GameObject square = Instantiate(
                prefab,
                center + position,
                Quaternion.identity);
            
            // Ajoute à ma liste de carrés
            squares.Add(square);
        }
    }
}

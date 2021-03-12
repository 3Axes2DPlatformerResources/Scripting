using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private CoinDisplayController coinDisplayController;
    public static CoinDisplayController CoinDisplayController { get; private set; }

    [SerializeField] private LifeDisplayController lifeDisplayController;
    public static LifeDisplayController LifeDisplayController { get; private set; }
    [SerializeField] private List<GameObject> objectsNotToDestroyOnLoad;
    [SerializeField] private SquareController squareController;
    private static SquareController SquareController;
    
    private void Awake() {
        CoinDisplayController = coinDisplayController;
        LifeDisplayController = lifeDisplayController;
        SquareController = squareController;
        
        squareController.FindRespawnPoint();
        squareController.Respawn();

        foreach (GameObject element in objectsNotToDestroyOnLoad)
            DontDestroyOnLoad(element);
    }

    public static void ChangeScene(string sceneName) {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.completed += HandleLevelLoaded;
    }

    private static void HandleLevelLoaded(AsyncOperation handle) {
        SquareController.FindRespawnPoint();
        SquareController.Respawn();
    }
}

using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour {
    private static bool isGameManagerPresent = false;
    [SerializeField] private string currentSceneName;
    private static GameManager gameManager;
    
    private void Awake() {
        if (!isGameManagerPresent) {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Setup", LoadSceneMode.Additive);
            asyncOperation.completed += HandleSetupSceneLoaded;
            isGameManagerPresent = true;
        } else {
            SaveFile saveFile = new SaveFile(currentSceneName,
                GameManager.SquareController.LifeCounter,
                GameManager.SquareController.CoinCounter);
            string json = JsonUtility.ToJson(saveFile);
            File.WriteAllText(LoadSave.SavePath, json);
        }
    }

    private void HandleSetupSceneLoaded(AsyncOperation asyncOperation) {
        gameManager = FindObjectOfType<GameManager>();
    }
}

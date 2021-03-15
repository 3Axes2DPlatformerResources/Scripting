using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSave : MonoBehaviour {
    public static string SavePath => Application.persistentDataPath + "/masauvegarde.json";

    void Awake() {
        if (File.Exists(SavePath)) {
            string content = File.ReadAllText(SavePath);
            SaveFile saveFile = JsonUtility.FromJson<SaveFile>(content);
            SceneManager.LoadScene(saveFile.currentScene);
        } else {
            SceneManager.LoadScene("Niveau1");
        }
    }
}

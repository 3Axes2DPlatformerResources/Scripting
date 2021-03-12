using System;

[Serializable]
public class SaveFile {
    public string currentScene;
    public int numberOfLives;
    public int numberOfCoins;

    public SaveFile(
        string currentScene,
        int numberOfLives,
        int numberOfCoins) {
        this.currentScene = currentScene;
        this.numberOfLives = numberOfLives;
        this.numberOfCoins = numberOfCoins;
    }
}
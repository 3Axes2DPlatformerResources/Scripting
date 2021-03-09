using TMPro;
using UnityEngine;

public class LifeDisplayController : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI lifeCounterText;

        public void ChangeText(int numberOfLives) {
                lifeCounterText.text = numberOfLives.ToString();
        }
}
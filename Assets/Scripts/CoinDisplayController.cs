using TMPro;
using UnityEngine;

public class CoinDisplayController : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI coinTextComponent;

    public void ChangeText(int numberOfCoins) {
        coinTextComponent.text = numberOfCoins.ToString();
    }
}

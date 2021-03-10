using TMPro;
using UnityEngine;

public class TutorialTextController : MonoBehaviour {
    [SerializeField] private GameObject tutorialWindowGameObject;
    [SerializeField] private TextMeshProUGUI tutorialTextComponent;
    [SerializeField] private TextMeshProUGUI tutorialButtonTextComponent;
    [SerializeField] private Dialogue dialogueToDisplay;

    private int currentDialogueListIndex;

    private void Awake() {
        currentDialogueListIndex = 0;
        tutorialTextComponent.text = dialogueToDisplay.List[currentDialogueListIndex];
    }

    public void HandleNextButtonClick() {
        currentDialogueListIndex++;
        if (currentDialogueListIndex < dialogueToDisplay.List.Count) {
            if (currentDialogueListIndex == dialogueToDisplay.List.Count - 1)
                tutorialButtonTextComponent.text = "Fermer";
            tutorialTextComponent.text = dialogueToDisplay.List[currentDialogueListIndex];
        } else {
            tutorialWindowGameObject.SetActive(false);
        }
    }
}

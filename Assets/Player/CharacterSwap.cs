using UnityEngine;

public class CharacterSwap : MonoBehaviour {

    public GameObject playerCharacters;
    private PlayerCharactersLoader charactersLoader;

    private void Start() {
        charactersLoader = new PlayerCharactersLoader(playerCharacters);
        CharacterSwapIndexTracker.LastId = charactersLoader.GetLastId();
        CharacterSwapIndexTracker.CurrentId = 0;
        charactersLoader.SetActiveCharacter(0);
    }

    public void NextCharacter() {
        charactersLoader.SetDeactiveCharacter(CharacterSwapIndexTracker.CurrentId);
        CharacterSwapIndexTracker.MoveToNextId();
        SpawnCharacterInMainMenu(CharacterSwapIndexTracker.CurrentId);
    }

    public void PreviousCharacter() {
        charactersLoader.SetDeactiveCharacter(CharacterSwapIndexTracker.CurrentId);
        CharacterSwapIndexTracker.MoveToPrevId();
        SpawnCharacterInMainMenu(CharacterSwapIndexTracker.CurrentId);
    }

    private void SpawnCharacterInMainMenu(int index) {
        GameObject character = charactersLoader.GetCharacter(index);
        charactersLoader.SetActiveCharacter(index);
        Rigidbody rigidBody = character.GetComponent<Rigidbody>();
        rigidBody.position = new Vector3(0, 4f, 0);
        rigidBody.rotation = Quaternion.Euler(45f, 0, 45f);
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }

}

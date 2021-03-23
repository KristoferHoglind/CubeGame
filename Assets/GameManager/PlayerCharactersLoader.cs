using System.Collections.Generic;
using UnityEngine;

public class PlayerCharactersLoader {

    private List<GameObject> playerCharactersList;

    public PlayerCharactersLoader(GameObject playerCharacters) {
        playerCharactersList = new List<GameObject>();
        for(int i = 0; i < playerCharacters.transform.childCount; i++) {
            playerCharactersList.Add(playerCharacters.transform.GetChild(i).gameObject);
        }
    }

    public List<GameObject> GetPlayerCharacters() {
        return playerCharactersList;
    }

    public int GetLastId() {
        return playerCharactersList.Count - 1;
    }

    public GameObject GetCharacter(int index) {
        return playerCharactersList[index];
    }

    public void SetActiveCharacter(int index) {
        playerCharactersList[index].SetActive(true);
    }

    public void SetDeactiveCharacter(int index) {
        playerCharactersList[index].SetActive(false);
    }

}

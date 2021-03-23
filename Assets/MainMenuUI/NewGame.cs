using UnityEngine;

public class NewGame : MonoBehaviour {

    public GameObject mainMenuScene1;
    public GameObject mainMenuScene2;

    private void Start() {
        PlayerStats.ResetPlayerStats(); // Always reset a players stats when visiting main menu
        mainMenuScene1.SetActive(true);
        mainMenuScene2.SetActive(false);
    }

    public void StartGame() {
        mainMenuScene1.SetActive(false);
        mainMenuScene2.SetActive(true);
    }

}

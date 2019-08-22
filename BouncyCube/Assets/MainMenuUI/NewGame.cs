using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{

    public GameObject startGameButtonUi;
    public GameObject nameInputField;
    public GameObject newGameButtonUi;

    private void Start()
    {
        PlayerStats.ResetPlayerStats(); // Always reset a players stats when visiting main menu
        startGameButtonUi.SetActive(false);
        nameInputField.SetActive(false);
        newGameButtonUi.SetActive(true);
    }

    public void StartGame()
    {
        startGameButtonUi.SetActive(true);
        nameInputField.SetActive(true);
        newGameButtonUi.SetActive(false);
    }

}

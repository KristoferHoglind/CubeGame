using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {

    public InputField inputField;
    public GameObject nameErrorText;

    public void SavePlayerName() {
        PlayerStats.Name = inputField.text;
    }

    private void Start() {
        nameErrorText.SetActive(false);
    }

    public void StartGame() {
        if(inputField.text.Equals("")) {
            nameErrorText.SetActive(true);
        } else {
            SavePlayerName();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            nameErrorText.SetActive(false);
        }
    }

    void Update() {
        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)) {
            StartGame();
        }
    }

}

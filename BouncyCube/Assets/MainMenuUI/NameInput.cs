using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour
{

    public InputField inputField;

    public void SavePlayerName()
    {
        PlayerStats.Name = inputField.text;
    }

    public void StartGame()
    {
        SavePlayerName();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}

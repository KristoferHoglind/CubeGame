using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUi;

    private bool isGameEnded = false;
    private const float restartDelay = 1f;

    public void EndGame()
    {
        if(!isGameEnded)
        {
            isGameEnded = true;
            Debug.Log("Game Over!");
            Invoke("Restart", restartDelay);
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("You won!");
        completeLevelUi.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUi;
    public ScoreCalculator scoreCalculator;

    private bool isGameEnded = false;
    private const float restartDelay = 1f;
    private int gameTotalScore = 0;

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
        gameTotalScore += scoreCalculator.GetLevelScore();
        Debug.Log("Your score: " + gameTotalScore);
        completeLevelUi.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int GetGameTotalScore()
    {
        return gameTotalScore;
    }

}

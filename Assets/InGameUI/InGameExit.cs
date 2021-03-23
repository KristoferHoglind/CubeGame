using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameExit : MonoBehaviour {
    private const int mainMenuId = 0;
    private HighScoreList highScoreList;

    public void ExitGame() {
        UpdateHighScore();
        SceneManager.LoadScene(mainMenuId);
    }

    private void UpdateHighScore() {
        highScoreList = new HighScoreList();
        highScoreList.CreateNewHighScore(PlayerStats.Name, PlayerStats.TotalScore);
    }

}

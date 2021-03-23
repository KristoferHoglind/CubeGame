using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {
    private const int mainMenuId = 0;
    private HighScoreList highScoreList;

    public void LoadNextLevel() {
        int nextSceneId = SceneManager.GetActiveScene().buildIndex + 1;
        int noScenes = SceneManager.sceneCountInBuildSettings;
        if(nextSceneId >= noScenes) {
            // If at last scene, update high score and take us back to main menu
            UpdateHighScore();
            SceneManager.LoadScene(mainMenuId);
        } else {
            SceneManager.LoadScene(nextSceneId); // Else; take us to next scene
        }
    }

    private void UpdateHighScore() {
        highScoreList = new HighScoreList();
        highScoreList.CreateNewHighScore(PlayerStats.Name, PlayerStats.TotalScore);
    }

}

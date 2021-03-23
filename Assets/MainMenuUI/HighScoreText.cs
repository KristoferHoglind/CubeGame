using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour {
    public Text highScoreText;

    private void Start() {
        string highScoreString = "High Score:";
        for(int i = 0; i < GameConstants.highScoreRecordList; i++) {
            string nameKey = i.ToString() + "_name";
            int offsetIdName = i + 1;
            string playerName = PlayerPrefs.GetString(nameKey, offsetIdName.ToString() + ".");
            string scoreKey = i.ToString() + "_score";
            int playerScore = PlayerPrefs.GetInt(scoreKey, 0);
            highScoreString += "\n";
            highScoreString += offsetIdName.ToString() + ". " + playerName + "\t" + playerScore;
        }
        highScoreText.text = highScoreString;
    }

}

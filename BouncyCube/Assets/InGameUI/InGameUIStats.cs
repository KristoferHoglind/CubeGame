using UnityEngine;
using UnityEngine.UI;

public class InGameUIStats : MonoBehaviour {
    public Text statsText;
    public Jump cubeJump;
    public Fail cubeFail;
    public ScoreCalculator scoreCalculator;

    private void Update() {
        string statsString = "Stats";
        statsString += "\n";
        statsString += statStringFormat("Jumps", cubeJump.GetNoJumps(), PlayerStats.TotalJumps);
        statsString += statStringFormat("Double Jumps", cubeJump.GetNoDoubleJumps(), PlayerStats.TotalDoubleJumps);
        statsString += statStringFormat("Fails", cubeFail.GetNoFails(), PlayerStats.TotalFails);
        statsString += statStringFormat("Score", scoreCalculator.GetLevelScore(), PlayerStats.TotalScore);
        statsText.text = statsString;
    }

    private string statStringFormat(string statName, int currentStat, int totalStat) {
        return statName + ": " + "\t" + currentStat + "\t" + "(" + totalStat + ")" + "\n";
    }

}

using UnityEngine;
using UnityEngine.UI;

public class InGameUIStats : MonoBehaviour {
    public Text statsText;
    public Fail cubeFail;
    public ScoreCalculator scoreCalculator;
    public GameObject playerCharacters;
    private PlayerCharactersLoader charactersLoader;
    private Jump playerJump;

    private void Start() {
        charactersLoader = new PlayerCharactersLoader(playerCharacters);
        GameObject player = charactersLoader.GetCharacter(CharacterSwapIndexTracker.CurrentId);
        playerJump = player.GetComponent<Jump>();
    }

    private void Update() {
        string statsString = "Stats";
        statsString += "\n";
        statsString += statStringFormat("Jumps", playerJump.GetNoJumps(), PlayerStats.TotalJumps);
        statsString += statStringFormat("Double Jumps", playerJump.GetNoDoubleJumps(), PlayerStats.TotalDoubleJumps);
        statsString += statStringFormat("Fails", cubeFail.GetNoFails(), PlayerStats.TotalFails);
        statsString += statStringFormat("Score", scoreCalculator.GetLevelScore(), PlayerStats.TotalScore);
        statsText.text = statsString;
    }

    private string statStringFormat(string statName, int currentStat, int totalStat) {
        return statName + ": " + "\t" + currentStat + "\t" + "(" + totalStat + ")" + "\n";
    }

}

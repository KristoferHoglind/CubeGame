using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject completeLevelUi;
    public ScoreCalculator scoreCalculator;
    public Fail playerFail;
    public GameObject playerCharacters;

    private const float restartDelay = 1f;
    private PlayerCharactersLoader characterLoader;
    private Jump playerJump;

    private void Start() {
        characterLoader = new PlayerCharactersLoader(playerCharacters);
        characterLoader.SetActiveCharacter(CharacterSwapIndexTracker.CurrentId);
        GameObject player = characterLoader.GetCharacter(CharacterSwapIndexTracker.CurrentId);
        playerJump = player.GetComponent<Jump>();
    }

    public void CompleteLevel() {
        // TODO: Remove all Debug-Log, this is integrated in InGameUI instead
        Debug.Log("You won!");

        PlayerStats.TotalScore += scoreCalculator.GetLevelScore();
        Debug.Log("Your total score: " + PlayerStats.TotalScore);
        Debug.Log("Your score on this level: " + scoreCalculator.GetLevelScore());

        PlayerStats.TotalJumps += playerJump.GetNoJumps();
        Debug.Log("Your total Number of Jumps: " + PlayerStats.TotalJumps);
        Debug.Log("Your number of Jumps on this level: " + playerJump.GetNoJumps());

        PlayerStats.TotalDoubleJumps += playerJump.GetNoDoubleJumps();
        Debug.Log("Your total Number of Double Jumps: " + PlayerStats.TotalDoubleJumps);
        Debug.Log("Your number of Double Jumps on this level: " + playerJump.GetNoDoubleJumps());

        PlayerStats.TotalFails += playerFail.GetNoFails();
        Debug.Log("Your total fails: " + PlayerStats.TotalFails);
        Debug.Log("Your fails on this level: " + playerFail.GetNoFails());

        completeLevelUi.SetActive(true);
    }

}

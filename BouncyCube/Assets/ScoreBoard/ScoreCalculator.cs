using UnityEngine;

public class ScoreCalculator : MonoBehaviour {
    public Fail playerFail;
    public GameObject playerCharacters;
    private PlayerCharactersLoader charactersLoader;
    private Jump playerJump;
    private const int defaultScore = 1000;
    private const int noFailureScore = 70000;
    private const float jumpScoreModifierLog = 0.1f;
    private const int jumpScoreModifierConst = -1500;
    private const float doubleJumpScoreModifierLog = 0.05f;
    private const int doubleJumpScoreModifierConst = -3000;
    private const int failsScoreModifier = -10000;

    private void Start() {
        charactersLoader = new PlayerCharactersLoader(playerCharacters);
        GameObject player = charactersLoader.GetCharacter(CharacterSwapIndexTracker.CurrentId);
        playerJump = player.GetComponent<Jump>();
    }

    public int GetLevelScore() {
        int totalScore = GetJumpScore() + GetDoubleJumpScore() + GetFailsScore();
        return totalScore;
    }

    private int GetJumpScore() {
        int noJumps = playerJump.GetNoJumps();
        float jumpScore = (defaultScore / ((jumpScoreModifierLog * noJumps) + jumpScoreModifierLog)) + (jumpScoreModifierConst * noJumps);
        return (int)Mathf.Ceil(jumpScore);
    }

    private int GetDoubleJumpScore() {
        int noDoubleJumps = playerJump.GetNoDoubleJumps();
        float doubleJumpScore = (defaultScore / ((doubleJumpScoreModifierLog * noDoubleJumps) + doubleJumpScoreModifierLog)) + (doubleJumpScoreModifierConst * noDoubleJumps);
        return (int)Mathf.Ceil(doubleJumpScore);
    }

    private int GetFailsScore() {
        return noFailureScore + (playerFail.GetNoFails() * failsScoreModifier);
    }

}

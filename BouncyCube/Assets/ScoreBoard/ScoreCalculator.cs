using UnityEngine;

public class ScoreCalculator : MonoBehaviour {
    public Jump cubeJump;
    public Fail cubeFail;
    private const int defaultScore = 1000;
    private const int noFailureScore = 70000;
    private const float jumpScoreModifierLog = 0.1f;
    private const int jumpScoreModifierConst = -1500;
    private const float doubleJumpScoreModifierLog = 0.05f;
    private const int doubleJumpScoreModifierConst = -3000;
    private const int failsScoreModifier = -10000;

    public int GetLevelScore() {
        int totalScore = GetJumpScore() + GetDoubleJumpScore() + GetFailsScore();
        return totalScore;
    }

    private int GetJumpScore() {
        int noCubeJumps = cubeJump.GetNoJumps();
        float jumpScore = (defaultScore / ((jumpScoreModifierLog * noCubeJumps) + jumpScoreModifierLog)) + (jumpScoreModifierConst * noCubeJumps);
        return (int)Mathf.Ceil(jumpScore);
    }

    private int GetDoubleJumpScore() {
        int noCubeDoubleJumps = cubeJump.GetNoDoubleJumps();
        float doubleJumpScore = (defaultScore / ((doubleJumpScoreModifierLog * noCubeDoubleJumps) + doubleJumpScoreModifierLog)) + (doubleJumpScoreModifierConst * noCubeDoubleJumps);
        return (int)Mathf.Ceil(doubleJumpScore);
    }

    private int GetFailsScore() {
        return noFailureScore + (cubeFail.GetNoFails() * failsScoreModifier);
    }

}

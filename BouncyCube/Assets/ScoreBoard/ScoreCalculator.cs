using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public Jump cubeJump;
    public Fail cubeFail;
    private const int defaultScore = 1000;
    private const float jumpScoreModifier = 0.1f;
    private const float doubleJumpScoreModifier = 0.01f;
    private const int failsScoreModifier = -1000;

    public int GetLevelScore()
    {
        int totalScore = GetJumpScore() + GetDoubleJumpScore() + GetFailsScore();
        return totalScore;
    }

    private int GetJumpScore()
    {
        int noCubeJumps = cubeJump.GetNoJumps();
        float jumpScore = defaultScore / ((jumpScoreModifier * noCubeJumps) + jumpScoreModifier);
        return (int)Mathf.Ceil(jumpScore);
    }

    private int GetDoubleJumpScore()
    {
        int noCubeDoubleJumps = cubeJump.GetNoDoubleJumps();
        float doubleJumpScore = defaultScore / ((doubleJumpScoreModifier * noCubeDoubleJumps) + doubleJumpScoreModifier);
        return (int)Mathf.Ceil(doubleJumpScore);
    }

    private int GetFailsScore()
    {
        return cubeFail.GetNoFails() * failsScoreModifier;
    }

}

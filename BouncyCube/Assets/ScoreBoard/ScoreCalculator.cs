using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public Jump cubeJump;
    private const int defaultScore = 1000;
    private const float jumpScoreModifier = 0.01f;
    private const float doubleJumpScoreModifier = 0.1f;

    public int GetLevelScore()
    {
        int totalScore = GetJumpScore() + GetDoubleJumpScore();
        return totalScore;
    }

    private int GetJumpScore()
    {
        int noCubeJumps = cubeJump.GetNoJumps();
        float jumpScore = defaultScore / (jumpScoreModifier * noCubeJumps);
        return (int)Mathf.Ceil(jumpScore);
    }

    private int GetDoubleJumpScore()
    {
        int noCubeDoubleJumps = cubeJump.GetNoDoubleJumps();
        float doubleJumpScore = defaultScore / (doubleJumpScoreModifier * noCubeDoubleJumps);
        return (int)Mathf.Ceil(doubleJumpScore);
    }

}

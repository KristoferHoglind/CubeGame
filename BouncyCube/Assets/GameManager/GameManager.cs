﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUi;
    public ScoreCalculator scoreCalculator;
    public Jump cubeJump;
    public Fail cubeFail;

    private bool isGameEnded = false;
    private const float restartDelay = 1f;

    public void EndGame()
    {
        if(!isGameEnded)
        {
            isGameEnded = true;
            Debug.Log("Game Over!");
            Invoke("Restart", restartDelay);
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("You won!");
        PlayerStats.TotalPoints += scoreCalculator.GetLevelScore();
        Debug.Log("Your total score: " + PlayerStats.TotalPoints);
        Debug.Log("Your score on this level: " + scoreCalculator.GetLevelScore());

        PlayerStats.TotalJumps += cubeJump.GetNoJumps();
        Debug.Log("Your total Number of Jumps: " + PlayerStats.TotalJumps);
        Debug.Log("Your number of Jumps on this level: " + cubeJump.GetNoJumps());

        PlayerStats.TotalDoubleJumps += cubeJump.GetNoDoubleJumps();
        Debug.Log("Your total Number of Double Jumps: " + PlayerStats.TotalDoubleJumps);
        Debug.Log("Your number of Double Jumps on this level: " + cubeJump.GetNoDoubleJumps());

        PlayerStats.TotalFails += cubeFail.GetNoFails();
        Debug.Log("Your total fails: " + PlayerStats.TotalFails);
        Debug.Log("Your fails on this level: " + cubeFail.GetNoFails());

        completeLevelUi.SetActive(true);
    }

}

using System;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreList {
    private List<HighScore> highScores;

    public HighScoreList() {
        highScores = new List<HighScore>();
        for(int i = 0; i < GameConstants.highScoreRecordList; i++) {
            highScores.Add(GetHighScoreFromPrefs(i));
        }
    }

    private HighScore GetHighScoreFromPrefs(int position) {
        string nameKey = position.ToString() + "_name";
        string playerName = PlayerPrefs.GetString(nameKey);
        string scoreKey = position.ToString() + "_score";
        int playerScore = PlayerPrefs.GetInt(scoreKey);
        return new HighScore(playerName, playerScore, position);
    }

    public void CreateNewHighScore(string name, int score) {
        if(IsNewHighScore(score)) {
            InsertHighScore(name, score, GetNewHighScorePosition(score));
            UpdatePrefs();
        }
        // Else; do nothing
    }

    private bool IsNewHighScore(int score) {
        return GetNewHighScorePosition(score) != -1;
    }

    private int GetNewHighScorePosition(int score) {
        foreach(HighScore highScore in highScores) {
            if(score > highScore.Score) {
                return highScores.IndexOf(highScore);
            }
        }
        return -1;
    }

    private void InsertHighScore(string name, int score, int position) {
        HighScore newHighScore = new HighScore(name, score, position);
        highScores.Insert(position, newHighScore);
        foreach(HighScore highScore in highScores) {
            highScore.Position = highScores.IndexOf(highScore);
        }
    }

    private void UpdatePrefs() {
        foreach(HighScore highScore in highScores) {
            SetPrefsFromHighScore(highScore);
        }
    }

    private void SetPrefsFromHighScore(HighScore highScore) {
        string nameKey = highScore.Position.ToString() + "_name";
        PlayerPrefs.SetString(nameKey, highScore.Name);
        string scoreKey = highScore.Position.ToString() + "_score";
        PlayerPrefs.SetInt(scoreKey, highScore.Score);
    }

    private class HighScore : IComparable {
        public HighScore(string Name, int Score, int Position) {
            this.Name = Name;
            this.Score = Score;
            this.Position = Position;
        }

        public string Name { get; }
        public int Score { get; }
        public int Position { set; get; }

        public int CompareTo(object obj) {
            if(obj == null) {
                return -1;
            }

            if(obj is HighScore) {
                HighScore otherHighScore = obj as HighScore;
                if(this.Score > otherHighScore.Score) {
                    return 1;
                } else if(this.Score <= otherHighScore.Score) {
                    return -1;
                }
            }

            return -1;
        }
    }
}

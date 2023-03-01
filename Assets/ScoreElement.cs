using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class ScoreElement : MonoBehaviour
{
    //ScoreElements
    public TMP_Text userText;
    public TMP_Text scoreText;
    public TMP_Text dateText;

    //Called by the HighscoreTable script.
    public void NewScoreElement(string _displayName, int _highScore)
    {
        userText.text = _displayName;
        scoreText.text = _highScore.ToString();
    }
}

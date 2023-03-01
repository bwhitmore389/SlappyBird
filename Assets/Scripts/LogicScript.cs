using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Rigidbody2D birdRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public ScenesManager scenesManager;
    public bool birdIsAlive = true;
    public Sprite Bird_flap;
    public Sprite Bird_shoot;
    public FirebaseScoreManager firebaseScoreManager;

    [ContextMenu("Increase Score")]

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }
}

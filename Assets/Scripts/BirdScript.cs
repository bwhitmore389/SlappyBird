using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public ScenesManager scenesManager;
    public bool birdIsAlive = true;
    public Sprite Bird_flap;
    public FirebaseScoreManager firebaseScoreManager;
    public Text scoreText;
    public float upperDeadZone = 25;
    public float lowerDeadZone = -25;

 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        } 

        if (transform.position.y < lowerDeadZone || transform.position.y > upperDeadZone) 
        {
            firebaseScoreManager.SaveGameData(int.Parse(scoreText.text));
            birdIsAlive = false;
            ScenesManager.Instance.LoadGameOver();
        }
    }

    //This method contains the loss conditions and instantiates the game over scene.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        firebaseScoreManager.SaveGameData(int.Parse(scoreText.text));
        birdIsAlive = false;
        ScenesManager.Instance.LoadGameOver();
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Auth;
using System;
using TMPro;

public class FirebaseScoreManager : MonoBehaviour
{
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;
    public GameObject playerScore;
    public Text scoreText;
    public TMP_InputField highScoreField;
    public TMP_InputField usernameField;
    public TMP_InputField recentScore;


    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != User)
        {
            bool signedIn = User != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && User != null)
            {
                Debug.Log("Signed out " + User.UserId);
            }
            User = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + User.UserId);
            }
        }
    }

    private void Awake()
    {
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
        User = auth.CurrentUser;
        StartCoroutine(LoadUserData());
        CheckUser();
    }

    //Check user methods notify Unity Editor that Firebase authorization is withheld through scene changes.
    private void HandleAuthStateChanged(object sender, EventArgs e)
    {
        CheckUser();
    }

    private void CheckUser()
    {
        if (FirebaseAuth.DefaultInstance.CurrentUser != null)
        {
            Debug.Log(message: "User is still logged in!");
        }
    }

    private IEnumerator UpdateHighScore(int score)
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("highScore").SetValueAsync(score);
        var DBTask2 = DBreference.Child("users").Child(User.UserId).Child("displayName").SetValueAsync(User.DisplayName);
        var DBTask3 = DBreference.Child("users").Child(User.UserId).Child("recentScore").SetValueAsync(score);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            Debug.LogWarning(message: "Score is now updated with Unity");
        }
    }

    //Saves game data to Firebase Database.
    //This method is called through the BirdScript.
    public void SaveGameData(int score)
    {
            StartCoroutine(UpdateHighScore(int.Parse(scoreText.text)));   
    }

    //Handles loading leaderboard data.
    private IEnumerator LoadUserData()
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            usernameField.text = "0";
            highScoreField.text = "0";
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            usernameField.text = snapshot.Child("displayName").Value.ToString();
            highScoreField.text = snapshot.Child("highScore").Value.ToString();
            recentScore.text = snapshot.Child("recentScore").Value.ToString();

        }
    }

    //The Log Out button on the Game Over screen utilizes this method to kill Firebase authorization.
    public void SignOutButton()
    {
        auth.SignOut();
        ScenesManager.Instance.LoadLogin();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;
using System;
using System.Linq;


public class HighscoreTable : MonoBehaviour
{
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;

    //ScoreElements
    public GameObject scoreElement;
    public Transform scoreboardContent;

    private void Awake()
    {
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
        User = auth.CurrentUser;
        StartCoroutine(LoadScoreboardData());
    }

    private IEnumerator LoadScoreboardData()
    {
        var DBTask = DBreference.Child("users").OrderByChild("highScore").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data is successfully retrieved
            DataSnapshot snapshot = DBTask.Result;
            Debug.Log(message: "Scoreboard data retrieved successfully!");

            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            //Destroy any pre-existing scoreboard elements
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                string displayName = childSnapshot.Child("displayName").Value.ToString();
                int highScore = int.Parse(childSnapshot.Child("highScore").Value.ToString());

                //Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(displayName, highScore);
            }
        }
    }
}

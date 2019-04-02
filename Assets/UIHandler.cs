// Copyright 2016 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

// Handler for UI buttons on the scene.  Also performs some
// necessary setup (initializing the firebase app, etc) on
// startup.
public class UIHandler : MonoBehaviour
{

    ArrayList leaderBoard;

    private const int MaxScores = 1000;
    private string logText = "";
    public Text displayScores;
    public Text nameText;
    public Text scoreText;
    public Text EmailText;
   // public GameObject NameNext;

    private string name = "";
    private string score = "";
    private string Email = "";
  //  private bool addScorePressed;

    const int kMaxLogSize = 16382;
    DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;

    // When the app starts, check to make sure that we have
    // the required dependencies to use Firebase, and if not,
    // add them if possible.
    void Start()
    {
       // addScorePressed = true;
        leaderBoard = new ArrayList();
        leaderBoard.Add("Firebase Top " + MaxScores.ToString() + " Scores");

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    // Initialize the Firebase database:
    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        // NOTE: You'll need to replace this url with your Firebase App's database
        // path in order for the database connection to work correctly in editor.
        app.SetEditorDatabaseUrl("https://club-app-3.firebaseio.com/");
        if (app.Options.DatabaseUrl != null) app.SetEditorDatabaseUrl(app.Options.DatabaseUrl);
        //StartListener();
    }


    // Exit if escape (or back, on mobile) is pressed.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    // A realtime database transaction receives MutableData which can be modified
    // and returns a TransactionResult which is either TransactionResult.Success(data) with
    // modified data or TransactionResult.Abort() which stops the transaction with no changes.
    TransactionResult AddScoreTransaction(MutableData mutableData)
    {
        List<object> Users = mutableData.Value as List<object>;

        if (Users == null)
        {
            Users = new List<object>();
        }

        // Now we add the new score as a new entry that contains the email address and score.
        Dictionary<string, object> newScoreMap = new Dictionary<string, object>();
        newScoreMap["Message"] = score;
        newScoreMap["Name"] = name;
        newScoreMap["Email"] = Email;
        Users.Add(newScoreMap);
        

        // You must set the Value to indicate data at that location has changed.
        mutableData.Value = Users;
        //return and log success
        return TransactionResult.Success(mutableData);
    }
    public void AddName()
    {
        name = nameText.text;
        //Email = EmailText.text;


        if (string.IsNullOrEmpty(name))
        {
   //         DebugLog("invalid score or email.");
            return;
        }
     //   DebugLog(String.Format("Attempting to add score {0} {1}",
        //  name, score.ToString()));

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users");

    //    DebugLog("Running Transaction...");
        // Use a transaction to ensure that we do not encounter issues with
        // simultaneous updates that otherwise might create more than MaxScores top scores.
        reference.RunTransaction(AddScoreTransaction)
          .ContinueWith(task => {
              if (task.Exception != null)
              {
          //        DebugLog(task.Exception.ToString());
              }
              else if (task.IsCompleted)
              {
       ///           DebugLog("Transaction complete.");
              }
          });

    }

    public void AddMessage()
    {
        name = nameText.text;
        score = scoreText.text;

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users");

     //   DebugLog("Running Transaction...");
        // Use a transaction to ensure that we do not encounter issues with
        // simultaneous updates that otherwise might create more than MaxScores top scores.
        reference.RunTransaction(AddScoreTransaction)
          .ContinueWith(task => {
              if (task.Exception != null)
              {
      //            DebugLog(task.Exception.ToString());
              }
              else if (task.IsCompleted)
              {
      //            DebugLog("Transaction complete.");
              }
          });

    }
    public void verifyemail()
    {
        if (EmailText.text == "")
        {

        }
        else
        {
            AddEmail();
        }
    }
    public void AddEmail()
    {
        Email = EmailText.text;
        

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Users");
      //  reference.GetValueAsync
      //  DebugLog("Running Transaction...");
        // Use a transaction to ensure that we do not encounter issues with
        // simultaneous updates that otherwise might create more
        reference.RunTransaction(AddScoreTransaction)
          .ContinueWith(task => {
              if (task.Exception != null)
              {
         //         DebugLog(task.Exception.ToString());
              }
              else if (task.IsCompleted)
              {
         //         DebugLog("Transaction complete.");
              }
          });

    }
}
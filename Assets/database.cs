using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class database : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://YOUR-FIREBASE-APP.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update () {
		
	}
    public class User
    {
        public string username;
        public string email;

        public User()
        {
        }

        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }


    }

}

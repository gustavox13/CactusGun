using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayServices : MonoBehaviour
{

    public static void UnlockAnchivement(string id)
    {
        Social.ReportProgress(id, 100.0f, success => { });
    }

    public static void ShowAchivement()
    {
        Social.ShowAchievementsUI();
    }

    public static void LogIn()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);

        // Google play Service
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Login Success");
            }else
            {
                Debug.Log("Login failed");
            }
        });
    }
}

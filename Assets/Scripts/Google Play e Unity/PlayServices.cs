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

        PlayGamesPlatform.DebugLogEnabled = true;
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

    public static void PostScore(long score, string leaderBoard)
    {
        Social.ReportScore(score, leaderBoard, (success => { }));
    }

    public static void ShowLeaderboard(string leardboard)
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(leardboard);
    }

    public static long GetPlayerScore(string leaderboard)//Retornar o valor atual do score para verificar se é maior ou não
    {
        long score = 0;
        PlayGamesPlatform.Instance.LoadScores(leaderboard, LeaderboardStart.PlayerCentered, 1, LeaderboardCollection.Public,
            LeaderboardTimeSpan.AllTime, (LeaderboardScoreData data) => { score = data.PlayerScore.value; });
        return score;
    }

  

}

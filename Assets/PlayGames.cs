using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class PlayGames : MonoBehaviour
{
    public int playerScore;
    string leaderboardID = "CgkImomN3q4MEAIQBQ";
    string achievementID = "CgkImomN3q4MEAIQAQ";
    string achievementID1 = "CgkImomN3q4MEAIQAg";
    string achievementID2 = "CgkImomN3q4MEAIQAw";
    string achievementID3 = "CgkImomN3q4MEAIQBA";
    public static PlayGamesPlatform platform;
    public static bool notLog=true;
    int x = 0;
    void Start()
    {


        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        if (notLog)
        { 
            Social.Active.localUser.Authenticate(success =>
            {
                if (success)
                {
                    Debug.Log("Logged in successfully");
                }
                else
                {
                    Debug.Log("Login Failed");
                }
            });
            x = PlayerPrefs.GetInt("HS", 0);
            AddScoreToLeaderboard(x);
            UpdateAchivements();

        }
    }

    public void AddScoreToLeaderboard(int x)
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(x, leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
    }

    public void ShowAchievements()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowAchievementsUI();
           
        }
    }

    public void UnlockAchievement()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100f, success => { });
        }
    } public void UnlockAchievement1()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID1, 100f, success => { });
        }
    }public void UnlockAchievement2()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID2, 100f, success => { });
        }
    }public void UnlockAchievement3()
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportProgress(achievementID3, 100f, success => { });
        }
    }
    private void UpdateAchivements()
    {
        if (x >= 10)
        {
            UnlockAchievement();


            if (x >= 25)
            {
                UnlockAchievement1();
                if (x >= 50)
                {
                    UnlockAchievement2();

                    if (x >= 100)
                    {
                        UnlockAchievement3();
                    }
                }

            }
        }
    }

}
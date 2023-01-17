using System;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabManager : MonoBehaviour
{
    [SerializeField] private SetNumber _setNumber;
    void Start()
    {
        Login();
    }

    // Login - Part 1
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    public void CreateOrLoginThis()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = "SYARIFID",
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account");
        Debug.Log(error.GenerateErrorReport());
    }

    private void OnSuccess(LoginResult result)
    {
        Debug.Log("Successfull login/account create!");

        GetDataTeman();
    }

    // Send Leaderboard - Part 2
    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate {
                    StatisticName = "HighScore",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult obj)
    {
        Debug.Log("Successfull leaderboard update");
    }

    [ContextMenu("Send Score Data = 1000")]
    private void SendScoreData1()
    {
        SendLeaderboard(1000);
    }

    [ContextMenu("Send Score Data = 2000")]
    private void SendScoreData()
    {
        SendLeaderboard(2000);
    }

    public void SendScoreData(int score)
    {
        SendLeaderboard(score);
    }

    [ContextMenu("Get Leaderboard")]
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };

        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
        }
    }

    // Send User Data - Part 3
    public void SaveDataTeman(int budi, int ipin, int ibnu)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string> {
                {"Budi", budi.ToString()},
                {"Ipin", ipin.ToString()},
                {"Ibnu", ibnu.ToString()}
            }
        };

        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void GetDataTeman()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);

        // Get Title Data - Nebengggg :D
        GetTitleData();
    }

    private void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Received user data.");

        if (result.Data != null && result.Data.ContainsKey("Budi") && result.Data.ContainsKey("Ipin") && result.Data.ContainsKey("Ibnu"))
        {
            _setNumber.SyncToTeks(iteks1: result.Data["Budi"].Value, iteks2: result.Data["Ipin"].Value, iteks3: result.Data["Ibnu"].Value);
        }
    }

    private void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successfull user data send!");
    }

    // Title Data - Part 4
    private void GetTitleData()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), OnTitleDataReceived, OnError);
    }

    private void OnTitleDataReceived(GetTitleDataResult result)
    {
        if (result.Data == null || result.Data.ContainsKey("Message") == false || result.Data.ContainsKey("Msh") == false)
        {
            Debug.Log("No Data Received.");

            return;
        }

        Debug.Log(result.Data["Message"]);
        Debug.Log(result.Data["Msh"]);
        Debug.Log("Successfull Title Data Received.");
    }
}


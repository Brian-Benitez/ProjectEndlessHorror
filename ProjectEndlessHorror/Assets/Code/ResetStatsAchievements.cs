using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStatsAchievements : MonoBehaviour
{
    private bool ResetStatsOnGameStart = false;
    private bool AlsoResetAchievements = false;

    private void Start()
    {
        /*
        if(SteamManager.Initialized)
        {
            if(ResetStatsOnGameStart)
                Steamworks.SteamUserStats.ResetAllStats(AlsoResetAchievements);
        }
        */
    }
}

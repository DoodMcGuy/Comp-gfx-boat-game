using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLap : MonoBehaviour
{
    private int lapCount = 0;
    private bool lapFlag = false;
    private List<System.DateTime> lapTimes = new List<System.DateTime>();

    public void EnemyLapTime()
    {
        lapTimes.Add(System.DateTime.Now);
        lapCount++;
    }

    public int EnemyGetLapCount()
    {
        return lapCount;
    }

    public void enemyswitchLapFlag()
    {
        lapFlag = !lapFlag;
    }

    public bool enemyGetLapFlag()
    {
        return lapFlag;
    }

    public string EnemyGetFastestTime()
    {

        var minTime = new System.TimeSpan();
        var deltaTime = new System.TimeSpan(9999, 9999, 9999);

        for (int i = 0; i < lapTimes.Count - 1; i++)
        {
            deltaTime = lapTimes[i + 1] - lapTimes[i];

            if (minTime > deltaTime)
                minTime = deltaTime;
        }

        return "Enemy won! \nCurrent time from start is: " + deltaTime.Minutes + ":" + deltaTime.Seconds + ":" + deltaTime.Milliseconds;

    }
}

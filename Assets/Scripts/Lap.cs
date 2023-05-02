using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private int lapCount = 0;
    private bool lapFlag = false;
    private List<System.DateTime> lapTimes = new List<System.DateTime>();

    public void LapTime()
    {
        lapTimes.Add(System.DateTime.Now);
        lapCount++;

        var logOut = "Lap " + lapCount + " at: ";
        Debug.Log(logOut);
        Debug.Log(System.DateTime.Now);
    }

    public int GetLapCount()
    {
        return lapCount;
    }

    public void switchLapFlag()
    {
        lapFlag = !lapFlag;
    }

    public bool getLapFlag()
    {
        return lapFlag;
    }

    public string GetFastestTime()
    {

        var minTime = new System.TimeSpan();
        var deltaTime = new System.TimeSpan(9999, 9999, 9999);

        for (int i = 0; i < lapTimes.Count - 1; i++)
        {
            deltaTime = lapTimes[i + 1] - lapTimes[i];

            if (minTime > deltaTime)
                minTime = deltaTime;
        }

        return "Fastest time was: " + deltaTime.Minutes + ":" + deltaTime.Seconds + ":" + deltaTime.Milliseconds;

    }
}

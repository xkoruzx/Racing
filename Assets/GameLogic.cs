using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public Transform[] checkpointArray;
    public static Transform[] checkpointA;

    public static int currentCheckpoint = 0;
    public static int currentLap = 0;

    public int Lap;
    public int MaxLaps = 3;

    public Vector3 startPos;
    public Transform player;


    public int playerPosition = 1;
    public int playerCount = 1;

    public Text lapText;
    public Text lapTimerText;
    public Text totalTimerText;
    public Text startTimerText;
    public Text positionTextUpper;
    public Text positionTextLower;

    public static float lapTimeCount;
    public static float totalTimeCount;

    public float[] lapTime = { 0, 0, 0 };
    public float[] totalTime = { 0, 0, 0 };

    private bool startTiming;
    // Start is called before the first frame update
    void Start()
    {
        player.position = startPos;
        positionTextUpper.text = playerPosition.ToString();
        positionTextLower.text = playerCount.ToString();

        StartCoroutine(SetOff());
    }

    IEnumerator SetOff()
    {
        Controller kartScript = player.GetComponent<Controller>();
        kartScript.Freeze();
        yield return new WaitForSeconds(1.0f);
        startTimerText.text = "2";
        yield return new WaitForSeconds(1.0f);
        startTimerText.text = "1";
        yield return new WaitForSeconds(1.0f);
        startTiming = true;
        kartScript.Unfreeze();
        startTimerText.text = "Go!!";
        startTimerText.color = Color.yellow;
        yield return new WaitForSeconds(1.0f);
        startTimerText.text = "";
    }    
    // Update is called once per frame
    void Update()
    {
        if (startTiming)
        {
            lapTimeCount += Time.deltaTime;
            totalTimeCount += Time.deltaTime;

            lapTime[0] = Mathf.Floor(lapTimeCount / 60.0f);
            lapTime[1] = Mathf.Floor(lapTimeCount) % 60;
            lapTime[2] = Mathf.Floor(lapTimeCount * 1000.0f) % 1000;

            totalTime[0] = Mathf.Floor(totalTimeCount / 60.0f);
            totalTime[1] = Mathf.Floor(totalTimeCount) % 60;
            totalTime[2] = Mathf.Floor(totalTimeCount * 1000.0f) % 1000;

        }

        lapTimerText.text = string.Format("{0:00}:{1:00}.{2:000}", lapTime[0], lapTime[1], lapTime[2]);
        totalTimerText.text = string.Format("{0:00}:{1:00}.{2:000}", totalTime[0], totalTime[1], totalTime[2]);

        //if the current lap is not equal to the lap, we want to reset lapTimer
        if (currentLap != Lap)
        {
            //if the lap is not the very first 0 lap, then reset the lapcount
            if (Lap != 0)
            {
                lapTimeCount = 0.0f;
            }
        }
        //set lap = currentlap so we can run checkpoints again
        Lap = currentLap;
        
        if (Lap > MaxLaps)
        {
            this.enabled = false; 
        }

        //if the lap is the very first one, display it as 1 rather than 0. Else display as lap
        if (Lap == 0)
        {
            lapText.text = "Lap " + (Lap + 1) + " of " + MaxLaps;
        }
        else if (Lap <= MaxLaps)
        {
            lapText.text = "Lap " + Lap + " of " + MaxLaps;
        }

        positionTextUpper.text = playerPosition.ToString();
        checkpointA = checkpointArray;
    }
}

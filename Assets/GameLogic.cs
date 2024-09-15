using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

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
        startTimerText.color = Color.green;
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

        positionTextUpper.text = playerPosition.ToString();
    }
}

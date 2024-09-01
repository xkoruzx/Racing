using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{

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
        positionTextUpper.text = playerPosition.ToString();
        positionTextLower.text = playerCount.ToString();

        startTiming = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

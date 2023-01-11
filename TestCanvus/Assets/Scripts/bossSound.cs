using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bossSound : MonoBehaviour
{
    int startVal = 0;
    int loopVal = 0;
    int bossVal = 0;
    bool switchTriggered = false;
    bool loopTriggered = false;
    bool startTriggered = false;
    bool firstTime = false;
    bool transitionStarted = false;
    float currentDecemialTime = 0;
    float currentTimeSong = 0;
    float[] timeStampFreedom = { 2.05f, 4.27f, 8.68f, 13.02f, 17.48f };
    float[] timeStampLight = { 0.73f, 2.90f, 5.12f, 7.30f, 9.50f, 11.68f, 13.88f, 16.07f, 18.27f, 20.47f };
    float[] timeStampMaster = { 2.87f, 5.77f, 8.72f, 11.63f, 14.60f, 20.43f, 23.37f };
    float[] timeStampRedemption = { 0.03f, 2.95f, 5.90f, 8.82f, 11.72f, 14.63f, 17.58f, 20.50f };
    float[] timeStampRevenge = { 2.85f, 5.77f, 8.70f, 11.62f, 14.55f, 17.48f, 20.40f, 23.33f };
    float[] timeStampTreasure = { 2.85f, 5.80f, 8.72f, 11.65f, 17.50f, 23.35f };
    float[] timeStampTruth = { 1.40f, 3.65f, 6.97f, 9.12f, 12.38f, 14.58f, 16.80f };
    float[] startingFullTime = {22.33f,26.06f,29.46f,26.36f,29.45f,24.00f,21.00f};
    [SerializeField] AudioClip[] start;
    [SerializeField] AudioClip[] loopMain;
    [SerializeField] AudioClip[] transitionFreedom;
    [SerializeField] AudioClip[] transitionLight;
    [SerializeField] AudioClip[] transitionMaster;
    [SerializeField] AudioClip[] transitionRedemption;
    [SerializeField] AudioClip[] transitionRevenge;
    [SerializeField] AudioClip[] transitionTreasure;
    [SerializeField] AudioClip[] transitionTruth;
    [SerializeField] AudioClip[] loopBoss;
    AudioClip audioTransition;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (startTriggered)
        {
            if (startTriggered && loopTriggered)
            {
                timeLogic();
            }
            if (switchTriggered && !firstTime && loopTriggered)
            {
                startTransition();
            }
            handleUpdate();
            loopSong();
        }
    }
    public void stopButton()
    {
        GetComponent<AudioSource>().Stop();
        currentTimeSong = 0;
        switchTriggered = false;
        loopTriggered = false;
        startTriggered = false;
        firstTime = false;
        transitionStarted = false;
    }
    void handleUpdate()
    {
        if (!loopTriggered&&startTriggered)
        {
            timeLogic();
        }
        if (currentDecemialTime>=startingFullTime[startVal]&&!loopTriggered)
        {
            loopTriggered = true;
            currentTimeSong = 0;
        }
    }
    public void startPressed()
    {
        startTriggered = true;
    }
    void loopSong()
    {
        if (switchTriggered && !GetComponent<AudioSource>().isPlaying&&loopTriggered&&transitionStarted)
        {
            GetComponent<AudioSource>().PlayOneShot(loopBoss[bossVal]);
        }
    }
    public void switchPressed()
    {
        if (loopTriggered)
        {
            handleTrasition(loopVal, bossVal);
            switchTriggered = true;
            Debug.Log("Pressed");
        }
    }
    void startTransition()
    {
        switch (startVal)
        {
            case 0:
                if (linearSearch(timeStampFreedom))
                {
                    GetComponent<AudioSource>().PlayOneShot(audioTransition);
                    firstTime = true;
                    transitionStarted = true;
                    Debug.Log("Worked");
                }
                break;
            case 1:
                if (linearSearch(timeStampLight))
                {
                    GetComponent<AudioSource>().PlayOneShot(audioTransition);
                    transitionStarted = true;
                    firstTime = true;
                }
                break;
            case 2:
                if (linearSearch(timeStampMaster))
                {
                    GetComponent<AudioSource>().PlayOneShot(audioTransition);
                    transitionStarted = true;
                    firstTime = true;
                }
                break;
            case 3:
                if (linearSearch(timeStampRedemption))
                {
                    GetComponent<AudioSource>().PlayOneShot(audioTransition);
                    transitionStarted = true;
                    firstTime = true;
                }
                break;
            case 4:
                if (linearSearch(timeStampRevenge))
                {
                    Debug.Log(currentDecemialTime);
                    GetComponent<AudioSource>().PlayOneShot(audioTransition);
                    transitionStarted = true;
                    firstTime = true;
                }
                break;
            case 5:
                if (linearSearch(timeStampTreasure))
                {
                    GetComponent<AudioSource>().PlayOneShot(audioTransition);
                    transitionStarted = true;
                    firstTime = true;
                }
                break;
            case 6:
                if (linearSearch(timeStampTruth))
                {
                    GetComponent<AudioSource>().PlayOneShot(audioTransition);
                    transitionStarted = true;
                    firstTime = true;
                }
                break;
            default:
                break;
        }
    }
    bool linearSearch(float[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == currentDecemialTime)
            {
                Debug.Log("Found TIme");
                return true;
            }
        }
        return false;
    }

    void handleTrasition(int valueMain, int valueBoss)
    {
        switch (valueMain)
        {
            case 0:
                audioTransition = transitionFreedom[valueBoss];
                break;
            case 1:
                audioTransition = transitionLight[valueBoss];
                break;
            case 2:
                audioTransition = transitionMaster[valueBoss];
                break;
            case 3:
                audioTransition = transitionRedemption[valueBoss];
                break;
            case 4:
                audioTransition = transitionRevenge[valueBoss];
                break;
            case 5:
                audioTransition = transitionTreasure[valueBoss];
                break;
            case 6:
                audioTransition = transitionTruth[valueBoss];
                break;
            default:
                break;
        }
    }
    void timeLogic()
    {
        decimal d = (decimal)currentTimeSong;
        d = decimal.Round(d, 2);
        currentTimeSong += 1 * Time.deltaTime;
        currentDecemialTime = (float)d;
        if (loopTriggered) {
            switch (loopVal)
            {
                case 0:
                    if (currentDecemialTime >= 17.34f)
                    {
                        currentTimeSong = 0;
                    }
                    break;
                case 1:
                    if (currentDecemialTime >= 21.57f)
                    {
                        currentTimeSong = 0;
                    }
                    break;
                case 2:
                    if (currentDecemialTime >= 23.25f)
                    {
                        currentTimeSong = 0;
                    }
                    break;
                case 3:
                    if (currentDecemialTime >= 23.20f)
                    {
                        currentTimeSong = 0;
                    }
                    break;
                case 4:
                    if (currentDecemialTime >= 23.25f)
                    {
                        currentTimeSong = 0;
                    }
                    break;
                case 5:
                    if (currentDecemialTime >= 23.26f)
                    {
                        currentTimeSong = 0;
                    }
                    break;
                case 6:
                    if (currentDecemialTime >= 17.34f)
                    {
                        currentTimeSong = 0;
                    }
                    break;
            }
        }
    }
    public void HandleInputDataBoss(int val)
    {
        switch (val)
        {
            case 0:
                bossVal = 0;
                break;
            case 1:
                Debug.Log("1");
                bossVal = 1;
                break;
            case 2:
                Debug.Log("2");
                bossVal = 2;
                break;
            case 3:
                Debug.Log("3");
                bossVal = 3;
                break;
            case 4:
                Debug.Log("4");
                bossVal = 4;
                break;
            case 5:
                Debug.Log("5");
                bossVal = 5;
                break;
            case 6:
                Debug.Log("6");
                bossVal = 6;
                break;
            default:
                break;
        }
    }
    public void HandleInputDataStart(int val)
    {
        switch (val)
        {
            case 0:
                startVal = 0;
                loopVal = 0;
                break;
            case 1:
                startVal = 1;
                loopVal = 1;
                break;
            case 2:
                startVal = 2;
                loopVal = 2;
                break;
            case 3:
                startVal = 3;
                loopVal = 3;
                break;
            case 4:
                startVal = 4;
                loopVal = 4;
                break;
            case 5:
                startVal = 5;
                loopVal = 5;
                break;
            case 6:
                startVal = 6;
                loopVal = 6;
                break;
            default:
                break;
        }
    }
}

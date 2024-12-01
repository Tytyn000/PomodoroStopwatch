using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CircularProgressBar : MonoBehaviour
{
    public Image CircleFill;
    public float Duration;
    private float TimeRemaining;
    public bool IsRunning = true;
    public bool IsPaused = false;
    public bool HadStarted;
    public TimerController TimerController;

    void Update()
    {
        if (IsRunning && HadStarted)
        {
            Duration = TimerController.DurationOfTheCycle;
            UpdateProgressBar();
        }
    }
    public void StartCountdown()
    {
        TimeRemaining = Duration;
        IsRunning = true;
    }
    private void UpdateProgressBar()
    {
        if (TimeRemaining > 0)
        {
            if (IsPaused == false)
            {
                TimeRemaining -= Time.deltaTime;
                CircleFill.fillAmount = TimeRemaining / Duration;
            }
        }
        else
        {
            IsRunning = false;
            ResetBar();
        }
    }
    public void ResetBar()
    {
        CircleFill.fillAmount = 1f;
        IsRunning = false;
    }
}

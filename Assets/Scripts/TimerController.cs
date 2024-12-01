using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimerController : MonoBehaviour
{
    public float DurationOfTheCycle;              
    public AudioSource AudioSource;
    public AudioSource EndCycleAudioSource;

    public GameObject PlayButton;                
    public GameObject StopButton;                
    public int TotalNumberOfSecondsRemaining;

    public int NumberOfMinutesRemaining;
    public int NumberOfSecondsRemaining;

    public Text TimeRemaining;
    private float ElapsedTime;
    public CircularProgressBar CircularProgressBar;
    public bool HadStarted;
    public GameObject StartButton;

    public GameObject MuteButton;
    public GameObject RetablishSoundButton;
    public bool IsMute;

    void Start()
    {
        DurationOfTheCycle = 25 * 60; 
        Time.timeScale = 1;
        CircularProgressBar.Duration = DurationOfTheCycle;
        CircularProgressBar.StartCountdown();
    }

    void Update()
    {
        if (Time.timeScale == 1 && HadStarted)
        {
            ElapsedTime += Time.unscaledDeltaTime;

            TotalNumberOfSecondsRemaining = Mathf.Max(0, (int)(DurationOfTheCycle - ElapsedTime));
            NumberOfMinutesRemaining = TotalNumberOfSecondsRemaining / 60;
            NumberOfSecondsRemaining = TotalNumberOfSecondsRemaining % 60;

            if (NumberOfSecondsRemaining < 10)
            {
                string FormattedSeconds = "0" + NumberOfSecondsRemaining.ToString();
                TimeRemaining.text = NumberOfMinutesRemaining + ":" + FormattedSeconds;
            }
            else
            {
                TimeRemaining.text = NumberOfMinutesRemaining + ":" + NumberOfSecondsRemaining.ToString();
            }

            if (ElapsedTime >= DurationOfTheCycle)
            {
                SwitchToOtherCycle(DurationOfTheCycle);
                ElapsedTime = 0;
            }
            if (TotalNumberOfSecondsRemaining == 61)
            {
                PlaySound();
            }
        }
    }


    public void SwitchToOtherCycle(float duration)
    {
        if (duration == 25 * 60)
        {
            DurationOfTheCycle = 5 * 60;
        }
        else
        {
            DurationOfTheCycle = 25 * 60;
        }
        ResetTime();
    }

    void ResetTime()
    {
        TotalNumberOfSecondsRemaining = (int)DurationOfTheCycle;
        AudioSource.Stop();
        EndCycleAudioSource.Play();
        CircularProgressBar.Duration = DurationOfTheCycle;
        CircularProgressBar.StartCountdown();
    }
    void PlaySound()
    {
        Time.timeScale = 1;
        AudioSource.Play();
    }
    public void PauseTimer()
    {
        Time.timeScale = 0;
        PlayButton.SetActive(!PlayButton.activeSelf);
        StopButton.SetActive(!StopButton.activeSelf);
        AudioSource.Pause();
        CircularProgressBar.IsPaused = true;
    }
    public void ResumeTimer()
    {
        Time.timeScale = 1;
        PlayButton.SetActive(!PlayButton.activeSelf);
        StopButton.SetActive(!StopButton.activeSelf);
        AudioSource.UnPause();
        CircularProgressBar.IsPaused = false;
    }
    public void StartTimerForTheFirstTime()
    {
        HadStarted = true;
        CircularProgressBar.HadStarted = true;
        StartButton.SetActive(false);
        CircularProgressBar.IsRunning = true;
        CircularProgressBar.IsPaused = false;
    }
    public void ChangeStateOfVolume()
    {
        MuteButton.SetActive(!MuteButton.activeSelf);
        RetablishSoundButton.SetActive(!RetablishSoundButton.activeSelf);
        IsMute = !IsMute;
        AudioSource.mute = IsMute;
        EndCycleAudioSource.mute = IsMute;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UgglaGames.SaveLoadSystem;
using UgglaGames.DeviceTimerSystem;

public class ClockSystem : MonoBehaviour
{
    [SerializeField] Text clockLabel;
    [SerializeField] int clickIntervalInSeconds;
    Timer timer = new Timer();

    private void Start()
    {
        LoadTimer();
    }    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SaveHour();
        }        

        if (timer != null && timer.GetTimeLeft().TotalSeconds > 0)
        {
            print($"timer running {timer.GetTimeLeft().TotalSeconds}");
            TimeSpan target = timer.GetTimeLeft();
            var displayFormatter = new ClockDisplayFormatter();
            clockLabel.text = displayFormatter.FormatClockDisplay(target);

            if (!clockLabel.gameObject.activeInHierarchy)
                clockLabel.gameObject.SetActive(true);
        }
        else if (clockLabel.gameObject.activeInHierarchy)
        {
            clockLabel.gameObject.SetActive(false);
        }
    }


    void SaveHour()
    {
        timer = new Timer(DateTime.Now, new TimerInterval(clickIntervalInSeconds));
        SaveTimer();
    }

    private void SaveTimer()
    {
        ISaver saver = new SaverAsBinary();
        saver.Save(timer, "clock");
    }

    
    private void LoadTimer()
    {
        ILoader loader = new LoaderFromBinary();
        timer = loader.Load<Timer>("clock");
    }
}

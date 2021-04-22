using System;
using UnityEngine;
using UnityEngine.UI;
using UgglaGames.SaveLoadSystem;
using UgglaGames.DeviceTimerSystem;

public class LootBoxButton : MonoBehaviour
{
    [SerializeField] Text clockLabel;
    [SerializeField] int clickIntervalInSeconds;
    Timer timer = new Timer();
    bool canOpen = true;

    private void Start()
    {
        LoadTimer();
    }

    private void Update()
    {
        if (timer == null)
            return;

        if (timer.GetTimeLeft().TotalSeconds > 0)
        {
            UpdateClockDisplay();

            if (canOpen)
                canOpen = false;
        }
        else if (clockLabel.gameObject.activeInHierarchy)
        {
            EnableOpen();
        }
    }

    /// <summary>
    /// Update clock display with time left to zero
    /// </summary>
    private void UpdateClockDisplay()
    {
        TimeSpan target = timer.GetTimeLeft();
        var displayFormatter = new ClockDisplayFormatter();
        clockLabel.text = displayFormatter.FormatClockDisplay(target);
    }

    /// <summary>
    /// Enable player to open the box
    /// </summary>
    private void EnableOpen()
    {
        canOpen = true;
        clockLabel.text = "Open";
        timer = null;
    }

    /// <summary>
    /// Open loot box
    /// </summary>
    public void Open()
    {
        if (!canOpen)
            return;

        //Do something like a reward
        StoreTimer();
    }

    /// <summary>
    /// Create timer and store in local device
    /// </summary>
    private void StoreTimer()
    {
        CreateTimer();
        SaveTimer();
    }

    /// <summary>
    /// Create timer instance
    /// </summary>
    private void CreateTimer()
    {
        timer = new Timer(DateTime.Now, clickIntervalInSeconds);
    }

    /// <summary>
    /// Save timer to local device
    /// </summary>
    private void SaveTimer()
    {
        ISaver saver = new SaverAsBinary();
        saver.Save(timer, "clock");
    }
    
    /// <summary>
    /// Load Timer from local device
    /// </summary>
    private void LoadTimer()
    {
        ILoader loader = new LoaderFromBinary();
        timer = loader.Load<Timer>("clock");
    }
}

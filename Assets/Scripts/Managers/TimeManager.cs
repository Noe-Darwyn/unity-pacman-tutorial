using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TimeManagerUI timeManagerUI;
    public static float timeSpeed = 1f;
    public static float timeSpeedSaved = 1f;

    void Start()
    {
        if (timeManagerUI == null)
        {
            Debug.LogWarning("TimeManagerUI reference not set in TimeManager. Attempting to find it in the scene.");
            timeManagerUI = FindObjectOfType<TimeManagerUI>();
            if (timeManagerUI == null)
            {
                Debug.LogError("TimeManagerUI not found in the scene. Please ensure there is a TimeManagerUI component present.");
            }
        }
        Time.timeScale = timeSpeed; // Initialize the game time scale
    }

    public void OnTimeStop()
    {
        Debug.Log("Time Stopped");
        timeSpeed = 0f;
        Time.timeScale = timeSpeed; // Pause the game
    }

    public void OnTimeResume()
    {
        Debug.Log("Time Resumed");
        timeSpeed = 1f;
        Time.timeScale = timeSpeed; // Resume the game
        UpdateUI();
    }

    public void OnTimeFastForward()
    {
        Debug.Log("Time Fast Forwarded");
        timeSpeed += 1f;
        if (timeSpeed >= 5f)
        {
            timeSpeed = 1f; // Reset to normal speed if it exceeds 5x
        }
        Time.timeScale = timeSpeed; // Fast forward the game
        UpdateUI();
    }

    public void OnSaveTimeSpeed()
    {
        Debug.Log("Time Speed Saved: " + timeSpeed);
        timeSpeedSaved = timeSpeed;
    }

    public void OnLoadTimeSpeed()
    {
        Debug.Log("Time Speed Loaded: " + timeSpeedSaved);
        timeSpeed = timeSpeedSaved;
        Time.timeScale = timeSpeed; // Restore the saved speed
    }

    void UpdateUI()
    {
        timeManagerUI?.UpdateTimeSpeedDisplay(timeSpeed);
    }
}

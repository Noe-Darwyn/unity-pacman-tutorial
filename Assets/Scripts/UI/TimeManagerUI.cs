using UnityEngine;
using UnityEngine.UI;

public class TimeManagerUI : MonoBehaviour
{
    public Image timeSpeedIndicator;
    public Sprite[] timeSpeedIndicators;

    public void UpdateTimeSpeedDisplay(float timeSpeed)
    {
        Debug.Log("Current Time Speed: " + ((int)timeSpeed -1) + "x");
        timeSpeedIndicator.sprite = timeSpeedIndicators[(int)timeSpeed -1];
    }
}

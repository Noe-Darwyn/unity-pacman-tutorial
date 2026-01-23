using System.Drawing;
using GhostCardSpace;
using PermanentUpgradeCardSpace;
using UnityEngine;

public class PermanentUpgradeManager : MonoBehaviour
{
    public GhostCard[] ghostCardData;
    public PermanentUpgradeCard[] permaUpgradeData;
    
    public int[] upgradedBaseSpeed { get; private set; }
    public int[] upgradedBaseSpeedMultiplier { get; private set; }
    public int[] upgradedChaseDuration { get; private set; }
    public int[] upgradedChaseSpeedMultiplier { get; private set; }
    //public int[] upgradedPackProximity { get; private set; }
    public int[] upgradedRespawnDuration { get; private set; }
    public int[] upgradedScatterSpeedMultiplier { get; private set; }
    public int[] upgradedScatterDuration { get; private set; }
    //public int[] upgradedCornerProximity { get; private set; }
    public int[] upgradedFrightenedSpeedMultiplier { get; private set; }
    void Start()
    {
        InitializeGhost();
    }

    void InitializeGhost()
    {
        for (int i = 0; i < ghostCardData.Length; i++)
        {
            upgradedBaseSpeed[i] = ghostCardData[i].baseSpeed + permaUpgradeData[i].baseSpeedIncrease;
            upgradedBaseSpeedMultiplier[i] = ghostCardData[i].baseSpeedMultiplier + permaUpgradeData[i].baseSpeedMultiplierIncrease;

            upgradedChaseDuration[i] = ghostCardData[i].chaseDuration + permaUpgradeData[i].chaseDurationIncrease;
            upgradedChaseSpeedMultiplier[i] = ghostCardData[i].chaseSpeedMultiplier + permaUpgradeData[i].chaseSpeedMultiplierIncrease;
            //upgradedPackProximity[i] = ghostCardData[i].packProximity - permaUpgradeData[i].packProximityDecrease;

            upgradedRespawnDuration[i] = ghostCardData[i].respawnDuration - permaUpgradeData[i].respawnDurationDecrease;

            upgradedScatterSpeedMultiplier[i] = ghostCardData[i].scatterSpeedMultiplier + permaUpgradeData[i].scatterSpeedMultiplierIncrease;
            upgradedScatterDuration[i] = ghostCardData[i].scatterDuration + permaUpgradeData[i].scatterDurationIncrease;
            //upgradedCornerProximity[i] = ghostCardData[i].scatterProximity - permaUpgradeData[i].cornerProximityDecrease;
            
            upgradedFrightenedSpeedMultiplier[i] = ghostCardData[i].frightenedSpeedMultiplier + permaUpgradeData[i].frightenedSpeedMultiplierIncrease;
        }
    }
}

using Unity.Mathematics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PermanentUpgradeCardSpace
{
    [CreateAssetMenu(fileName = "New Permanent Upgrade Card", menuName = "Permanent Upgrade Card")]
    public class PermanentUpgradeCard : ScriptableObject
    {
        [Header("Basic Info")]
        public Sprite Sprite;
        public string upgradeName;
        public string description;

        [Header("Movement and Behavior Stats")]
        [Header("Base Stats")]
        public int baseSpeedIncrease;
        public int baseSpeedMultiplierIncrease;

        [Header("Chase Stats")]
        public int chaseDurationIncrease;
        public int chaseSpeedMultiplierIncrease;
        // public int packProximityDecrease;

        [Header("Spawn Stats")]
        public int respawnDurationDecrease;

        [Header("Scatter Stats")]
        public int scatterSpeedMultiplierIncrease;
        public int scatterDurationIncrease;

        [Header("Frightened Stats")]
        public int frightenedSpeedMultiplierIncrease;

        public void DisplayCardInfo()
        {
            Debug.Log($"Upgrade Name: {upgradeName}\n" +
                      $"Description: {description}\n" +
                      $"Base Speed Increase: {baseSpeedIncrease}\n" +
                      $"Base Speed Multiplier Increase: {baseSpeedMultiplierIncrease}\n" +
                      $"Chase Duration Increase: {chaseDurationIncrease}\n" +
                      $"Chase Speed Multiplier Increase: {chaseSpeedMultiplierIncrease}\n" +
                      // $"Pack Proximity Decrease: {packProximityDecrease}\n" +
                      $"Respawn Duration Decrease: {respawnDurationDecrease}\n" +
                      $"Scatter Speed Multiplier Increase: {scatterSpeedMultiplierIncrease}\n" +
                      $"Scatter Duration Increase: {scatterDurationIncrease}\n" +
                      $"Frightened Speed Multiplier Increase: {frightenedSpeedMultiplierIncrease}");
        }
    }
}

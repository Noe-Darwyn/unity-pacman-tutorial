using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GhostCardSpace;
using UnityEngine.PlayerLoop;
using UnityEngine.Analytics;

public class GhostDisplay : MonoBehaviour
{

    void Start()
    {
        InitializeCardDisplay();
    }

    public void InitializeCardDisplay()
    {
        //for (int i = 0; i < analytics.Length; i++)
        //{
        //    analytics[i].ghostImage.sprite = cardData[i].Sprite;
        //    lifeImage.sprite = cardData[i].Sprite;
//
        //    traitText.text = cardData[i].trait.ToString();
//
        //    baseSpeedText.text = cardData[i].baseSpeed.ToString();
//
        //    chaseDurationText.text = cardData[i].chaseDuration.ToString();
        //    chaseSpeedText.text = cardData[i].chaseSpeedMultiplier.ToString();
        //    packProximityText.text = cardData[i].packProximity.ToString();
        //    respawnDurationText.text = cardData[i].respawnDuration.ToString();
//
        //    scatterDurationText.text = cardData[i].scatterDuration.ToString();
        //    scatterSpeedText.text = cardData[i].scatterSpeedMultiplier.ToString();
        //    scatterProximityText.text = cardData[i].scatterProximity.ToString();
//
        //    frightenedSpeedText.text = cardData[i].frightenedSpeedMultiplier.ToString();
        //}
    }

}

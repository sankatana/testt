using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.Localization;

public class test : MonoBehaviour
{
    public LocalizeStringEvent localizedStringEvent;//assign it its value in the Unity editor
    private LocalizedString localizedString;
    private IntVariable playerScore = null;

    private void Start()
    {

        localizedString = localizedStringEvent.StringReference;

        if (!localizedString.TryGetValue("0", out var variable))
        {
            playerScore = new IntVariable();
            localizedString.Add("0", playerScore);
        }
        else
        {
            playerScore = variable as IntVariable;
        }
    }

    public void updateScore()
    {
        playerScore.Value = 10;
    }
}


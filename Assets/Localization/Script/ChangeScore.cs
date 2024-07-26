using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using TMPro;
using System;
using UnityEngine.Localization.Components;

using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class ChangeScore : MonoBehaviour
{
    private LocalizedString localStringScore=null;
    [SerializeField] LocalizeStringEvent localStringScoreE;
    [SerializeField] TextMeshProUGUI textComp;

  //  int score = 0;
    /*[SerializeField]*/ IntVariable score = null;
    int point = 1;

    private void OnEnable()
    {
       // localStringScore = localStringScoreE.StringReference;
        if (localStringScoreE.StringReference.TryGetValue("0", out var variable))
        {
            score = new IntVariable();
            localStringScoreE.StringReference.Add("0", score);
        }
        else
        {
            score = variable as IntVariable;
        }
        point++;
        score.Value = point;
    }

    //private void OnDisable()
    //{
    //    localStringScore.StringChanged -= UpdateText;
    //}
    //private void UpdateText(int value)
    //{
    //    score.Value = value;

    //}

    public void IncreaseScore()
    {
    
    }
}

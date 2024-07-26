using System.Collections;
using System.Collections.Generic;
using UnityEditor.Localization;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.Utilities;
using UnityEngine.Localization.Tables;
using TMPro;
using UnityEngine.Localization.Components;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class LocalizationManager : MonoBehaviour
{
    //[SerializeField] StringTable table;
    [SerializeField] int id;
    [SerializeField] StringTableCollection tableName;
    [SerializeField] StringTableCollection tableOption;
    [SerializeField] LocalizeStringEvent prefab;
    Dictionary<string, LocalizeStringEvent> strings=new Dictionary<string, LocalizeStringEvent>();

    // Start is called before the first frame update
    void Start()
    {
        LocalizeStringEvent name = Instantiate(prefab, transform);
        name.SetTable(tableName.name);
        name.SetEntry(id.ToString());

        strings.Add("name", name);

        foreach (var entry in tableOption.SharedData.Entries)
        {
            LocalizeStringEvent text = Instantiate(prefab, transform);
            text.SetTable(tableOption.name);
            text.SetEntry(entry.Key);
            text.GetComponent<TextMeshProUGUI>().color = Color.green;
            strings.Add(entry.Key, text);
        }


    }

    void SetUpLocal()
    {

        strings["name"].SetEntry(id.ToString());
        LocalizedString a=strings["name"].StringReference;
        a.Arguments[0] = "+1";
        a.RefreshString();
       

        foreach (var entry in tableOption.SharedData.Entries)
        {
            /*LocalizedString text = */
            Debug.Log(strings[entry.Key].StringReference);
            // strings[entry.Key].StringReference.Arguments[0] = " 10 ";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) updateScore(strings["name"]," +10");
        if(Input.GetKeyDown(KeyCode.Escape)) updateScore(strings["name"], " +99");

    }

    public void updateScore(LocalizeStringEvent _localizeStringEvent,string _text)
    {

        LocalizedString localizedString = _localizeStringEvent.StringReference;

        StringVariable lvl;
        if (!localizedString.TryGetValue("0", out var variable))
        {
            lvl = new StringVariable();
            localizedString.Add("0", lvl);
        }
        else
        {
            lvl = variable as StringVariable;
        }

        lvl.Value =_text;

        localizedString.RefreshString();
      //  Debug.Log(lvl.Value);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    private static QuestManager _instance = null;
    public static QuestManager Instance
    {
        get { return QuestManager._instance; }
    }
    public QuestManager()
    {
        QuestManager._instance = this;
    }

    //public GameObject questPrintBox;
    //public GameObject displayPrefab;

    public void UpdateDisplay(string title, string body)
    {
        // Debug.Log(title);
        // Debug.Log(body);
        DisplayText.text = "<b>" + title + "</b>\n" + body;
        DisplayText.gameObject.SetActive(true);
        {
            if (questUI.activeSelf == false)
                {
                    questUI.SetActive(!questUI.activeSelf);
                }
        }
    }
    public Text DisplayText;
    // public Transform newParent;
    public GameObject questUI;
}